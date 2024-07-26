using DotNetBoilerplate.Application.DeviceCategories.Get;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.DeviceCategories.Get;

public record GetDeviceCategoryByIdQuery(Guid Id) : IQuery<DeviceCategoryDto>;
