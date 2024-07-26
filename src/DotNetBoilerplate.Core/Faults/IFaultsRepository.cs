namespace DotNetBoilerplate.Core.Faults;
public interface IFaultsRepository
{
    Task<Fault?> GetByIdAsync(Guid id);

    Task<List<Fault>> GetAllAsync();

    Task AddAsync(Fault fault);

    Task UpdateAsync(Fault fault);

    Task DeleteAsync(Fault fault);   
}