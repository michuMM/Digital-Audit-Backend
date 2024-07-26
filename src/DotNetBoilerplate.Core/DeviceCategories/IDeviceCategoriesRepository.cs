using DotNetBoilerplate.Core.DeviceCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IDeviceCategoriesRepository
{
    Task<DeviceCategory?> GetByIdAsync(Guid id);

    Task<List<DeviceCategory>> GetAllAsync();

    Task AddAsync(DeviceCategory deviceCategory);

    Task UpdateAsync(DeviceCategory deviceCategory);

    Task DeleteAsync(DeviceCategory deviceCategory);

    Task<bool> IsDeviceCategoryUniqueAsync(string deviceCategory, Guid categoryid, Guid organizationId);
}