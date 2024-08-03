using DotNetBoilerplate.Core.DeviceAssignments;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.DeviceAssignments.Get
{
    internal sealed class GetAllDeviceAssignmentsByOrganizationIdHandler(
        IDeviceAssignmentsRepository deviceAssignmentsRepository
    ) : IQueryHandler<GetAllDeviceAssignmentsByOrganizationIdQuery, List<DeviceAssignmentDto>>
    {
        public async Task<List<DeviceAssignmentDto>> HandleAsync(GetAllDeviceAssignmentsByOrganizationIdQuery query)
        {
            Console.WriteLine("Wykonuje Handlera");
            var deviceAssignments = await deviceAssignmentsRepository.GetAllByOrganizationIdAsync(query.OrganizationId);
            return deviceAssignments.Select(da => new DeviceAssignmentDto(da.Id, da.DeviceId, da.EmployeeId, da.OrganizationId, da.IssueDate, da.ReturnDate, da.ConditionOnReturn)).ToList();
        }
    }
}