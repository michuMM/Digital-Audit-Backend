using DotNetBoilerplate.Core.DeviceCategories;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

internal sealed class InMemoryDeviceCategoriesRepository : IDeviceCategoriesRepository
{
    private readonly List<DeviceCategory> deviceCategories = [];
    public Task<DeviceCategory?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    // Tutaj trzeba wziąć pod uwagę powtarzanie się nazw w różnych kategoriach
    public Task<bool> IsDeviceCategoryUniqueAsync(string deviceCategory, Guid categoryid, Guid organizationId)
    {
        throw new NotImplementedException();
    }
}
