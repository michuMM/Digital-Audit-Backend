using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.DeviceCategories.Update;

public sealed record UpdateDeviceCategoryCommand(string categoryName, Guid categoryId, Guid organizationId) : ICommand<Guid>;
