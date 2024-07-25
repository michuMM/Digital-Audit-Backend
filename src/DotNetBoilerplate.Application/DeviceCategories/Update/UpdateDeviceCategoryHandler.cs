using DotNetBoilerplate.Core.DeviceCategories;
using DotNetBoilerplate.Core.DeviceCategories.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.DeviceCategories.Update;

internal class UpdateDeviceCategoryHandler(
    IDeviceCategoriesRepository deviceCategoriesRepository,
    IContext context
) : ICommandHandler<UpdateDeviceCategoryCommand>
{
    public async Task HandleAsync(UpdateDeviceCategoryCommand command)
    {
        var deviceCategory = await deviceCategoriesRepository.GetByIdAsync(command.categoryId);

        if (deviceCategory is null)
        {
            throw new DeviceCategoryIsNullException(command.categoryId);
        }

        var isDeviceCategoryUnique = await deviceCategoriesRepository.IsDeviceCategoryUniqueAsync(command.categoryName, command.categoryId, command.organizationId);

        deviceCategory.UpdateCategory(command.categoryName, isDeviceCategoryUnique);

        await deviceCategoriesRepository.UpdateAsync(deviceCategory);
    }
}
