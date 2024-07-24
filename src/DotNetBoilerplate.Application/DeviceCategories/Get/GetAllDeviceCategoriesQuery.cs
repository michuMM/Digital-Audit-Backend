using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.DeviceCategories.Get
{
    public sealed class GetAllDeviceCategoriesQuery : IQuery<List<DeviceCategoryDto>>;
}
