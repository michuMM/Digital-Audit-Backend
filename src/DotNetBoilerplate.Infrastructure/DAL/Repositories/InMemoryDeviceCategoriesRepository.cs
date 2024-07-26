using DotNetBoilerplate.Core.DeviceCategories;
using DotNetBoilerplate.Core.DeviceCategories.Exceptions;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

internal sealed class InMemoryDeviceCategoriesRepository : IDeviceCategoriesRepository
{
    private readonly List<DeviceCategory> deviceCategories = [];
    public Task<DeviceCategory?> GetByIdAsync(Guid id)
    {
        var deviceCategory = deviceCategories.Find(x => x.CategoryId == id);

        return Task.FromResult(deviceCategory);
    }

    public Task<List<DeviceCategory>> GetAllAsync()
    {
        return Task.FromResult(deviceCategories);
    }

    public Task AddAsync(DeviceCategory deviceCategory)
    {
        deviceCategories.Add(deviceCategory);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(DeviceCategory deviceCategory)
    {
        var existingDeviceCategory = deviceCategories.FirstOrDefault(x => x.CategoryId == deviceCategory.CategoryId);

        if (existingDeviceCategory == null)
        {
            throw new DeviceCategoryIsNullException(deviceCategory.CategoryId);
        }

        existingDeviceCategory.CategoryName = deviceCategory.CategoryName;

        return Task.CompletedTask;
    }

    public async Task DeleteAsync(DeviceCategory deviceCategory)
    {
        deviceCategories.Remove(deviceCategory);
        await Task.CompletedTask;
    }

    // Tutaj trzeba wziąć pod uwagę powtarzanie się nazw w różnych kategoriach
    public Task<bool> IsDeviceCategoryUniqueAsync(string deviceCategory, Guid categoryId, Guid organizationId)
    {
        var isCategoryUnique = deviceCategories
            .Where(x => x.OrganizationId == organizationId && x.CategoryId != categoryId)
            .All(x => x.CategoryName != deviceCategory);

        return Task.FromResult(isCategoryUnique);
    }
}
