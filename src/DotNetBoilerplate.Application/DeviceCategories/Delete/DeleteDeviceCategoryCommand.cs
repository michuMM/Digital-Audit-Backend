using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.DeviceCategories.Delete;

public sealed record DeleteDeviceCategoryCommand(Guid id) : ICommand<Guid>;
