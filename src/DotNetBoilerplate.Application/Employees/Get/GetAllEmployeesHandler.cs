using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using System.Linq;

namespace DotNetBoilerplate.Application.Employees.Get
{
    internal sealed class GetAllEmployeesHandler(
        IEmployeesRepository employeesRepository
    ) : IQueryHandler<GetAllEmployeesQuery, List<EmployeeDto>>
    {
        public async Task<List<EmployeeDto>> HandleAsync(GetAllEmployeesQuery query)
        {
            var employees = await employeesRepository.GetAllAsync();
            return employees.Select(e => new EmployeeDto(e.Id, e.OrganizationId, e.FirstName, e.LastName, e.Email, e.Phone)).ToList();
        }
    }
}