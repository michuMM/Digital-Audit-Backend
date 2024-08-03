using DotNetBoilerplate.Core.Faults;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Faults.Read
{
    internal sealed class GetAllFaultsByOrganizationIdHandler(
        IFaultsRepository faultsRepository
    ) : IQueryHandler<GetAllFaultsByOrganizationIdQuery, List<FaultDto>>
    {
        public async Task<List<FaultDto>> HandleAsync(GetAllFaultsByOrganizationIdQuery query)
        {            
            var faults = await faultsRepository.GetAllByOrganizationIdAsync(query.OrganizationId);
            return faults.Select(f => new FaultDto(f.Id, f.DeviceId, f.ReporterId, f.OrganizationId, f.Name, f.Description, f.DeviceStatus, f.DateIssuedForRepair, f.PlannedReturnDate, f.RepairDate)).ToList();
        }
    }
}