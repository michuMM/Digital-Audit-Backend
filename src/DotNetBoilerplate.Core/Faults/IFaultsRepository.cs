namespace DotNetBoilerplate.Core.Faults;
public interface IFaultsRepository
{
    Task<Fault?> GetByIdAsync(Guid id);

    Task<List<Fault>> GetAllAsync();

    Task<List<Fault>> GetAllByOrganizationIdAsync(Guid organizationId);

    Task AddAsync(Fault fault);

    Task UpdateAsync(Fault fault);

    Task DeleteAsync(Fault fault);   
}