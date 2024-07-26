using DotNetBoilerplate.Core.DeviceCategories;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.DeviceCategories.Get
{
    internal sealed class GetAllDeviceCategoriesHandler(
        IDeviceCategoriesRepository deviceCategoriesRepository
    ) : IQueryHandler<GetAllDeviceCategoriesQuery, List<DeviceCategoryDto>>
    {
        public async Task<List<DeviceCategoryDto>> HandleAsync(GetAllDeviceCategoriesQuery query)
        {
            var deviceCategories = await deviceCategoriesRepository.GetAllAsync();
            return deviceCategories.Select(d => new DeviceCategoryDto(d.CategoryId, d.OrganizationId, d.CategoryName)).ToList();
        }
    }
}
