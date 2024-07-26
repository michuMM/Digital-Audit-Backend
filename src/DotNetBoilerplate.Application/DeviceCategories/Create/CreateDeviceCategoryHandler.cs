using DotNetBoilerplate.Core.DeviceCategories;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using FluentValidation;

namespace DotNetBoilerplate.Application.DeviceCategories.Create;

internal sealed class CreateDeviceCategoryHandler(IDeviceCategoriesRepository deviceCategoriesRepository, IValidator<CreateDeviceCategoryCommand> validator) : ICommandHandler<CreateDeviceCategoryCommand, Guid>
{
    private readonly IDeviceCategoriesRepository _deviceCategoriesRepository = deviceCategoriesRepository;
    private readonly IValidator<CreateDeviceCategoryCommand> _validator = validator;

    public async Task<Guid> HandleAsync(CreateDeviceCategoryCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var isDeviceCategoryUnique = await _deviceCategoriesRepository.IsDeviceCategoryUniqueAsync(command.CategoryName, Guid.Empty, command.OrganizationId);

        var deviceCategory = DeviceCategory.CreateCategory(
            command.OrganizationId,
            command.CategoryName
        );

        await _deviceCategoriesRepository.AddAsync(deviceCategory);

        return deviceCategory.CategoryId;
    }
}
