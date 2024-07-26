using DotNetBoilerplate.Core.DeviceCategories;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.DeviceCategories.Get;

public sealed class GetDeviceCategoryByIdHandler(IDeviceCategoriesRepository deviceCategoriesRepository) : IQueryHandler<GetDeviceCategoryByIdQuery, DeviceCategoryDto>
{
    private readonly IDeviceCategoriesRepository _deviceCategoriesRepository = deviceCategoriesRepository;

    public async Task<DeviceCategoryDto?> HandleAsync(GetDeviceCategoryByIdQuery query)
    {
        var deviceCategory = await _deviceCategoriesRepository.GetByIdAsync(query.Id);

        if (deviceCategory is null)
        {
            return null;
        }

        return new DeviceCategoryDto(
            deviceCategory.CategoryId,
            deviceCategory.OrganizationId,
            deviceCategory.CategoryName
        );
    }
}
