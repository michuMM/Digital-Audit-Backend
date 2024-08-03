using DotNetBoilerplate.Core.DeviceAssignments;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.DeviceAssignments.Get
{
    internal sealed class GetAllDeviceAssignmentsHandler(
        IDeviceAssignmentsRepository deviceAssignmentsRepository
    ) : IQueryHandler<GetAllDeviceAssignmentsQuery, List<DeviceAssignmentDto>>
    {
        public async Task<List<DeviceAssignmentDto>> HandleAsync(GetAllDeviceAssignmentsQuery query)
        {
            var deviceAssignments = await deviceAssignmentsRepository.GetAllAsync();
            return deviceAssignments.Select(d => new DeviceAssignmentDto(
                d.Id, 
                d.DeviceId,
                d.EmployeeId, 
                d.OrganizationId,
                d.IssueDate, 
                d.ReturnDate,
                d.ConditionOnReturn
            )).ToList();
        }
    }
}