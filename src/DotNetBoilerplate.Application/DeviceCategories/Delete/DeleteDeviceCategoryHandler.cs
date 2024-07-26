using DotNetBoilerplate.Application.DeviceCategories.Delete;
using DotNetBoilerplate.Core.DeviceCategories;
using DotNetBoilerplate.Core.DeviceCategories.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;


namespace DotNetBoilerplate.Application.DeviceCategories.Delete;

internal sealed class DeleteDeviceCategoryHandler(
    IDeviceCategoriesRepository deviceCategoriesRepository,
    IContext context
) : ICommandHandler<DeleteDeviceCategoryCommand>
{
    public async Task HandleAsync(DeleteDeviceCategoryCommand command)
    {
        var deviceCategory = await deviceCategoriesRepository.GetByIdAsync(command.id);

        if (deviceCategory is null)
        {
            throw new DeviceCategoryIsNullException(command.id);
        }

        await deviceCategoriesRepository.DeleteAsync(deviceCategory);
    }
}
