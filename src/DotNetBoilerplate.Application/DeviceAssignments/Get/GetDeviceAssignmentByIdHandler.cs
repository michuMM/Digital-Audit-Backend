using DotNetBoilerplate.Core.DeviceAssignments;
using DotNetBoilerplate.DeviceAssignments;
using DotNetBoilerplate.DeviceAssignments.Get;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.DeviceAssignments.Get;

public sealed class GetDeviceAssignmentByIdHandler : IQueryHandler<GetDeviceAssignmentByIdQuery, DeviceAssignmentDto>
{
    private readonly IDeviceAssignmentsRepository _deviceAssignmentsRepository;

    public GetDeviceAssignmentByIdHandler(IDeviceAssignmentsRepository deviceAssignmentsRepository)
    {
        _deviceAssignmentsRepository = deviceAssignmentsRepository;
    }

    public async Task<DeviceAssignmentDto?> HandleAsync(GetDeviceAssignmentByIdQuery query)
    {
        var deviceAssignment = await _deviceAssignmentsRepository.GetByIdAsync(query.Id);
        if (deviceAssignment is null)
        {
            return null;
        }

        return new DeviceAssignmentDto(
            deviceAssignment.Id,
            deviceAssignment.DeviceId,
            deviceAssignment.EmployeeId,
            deviceAssignment.IssueDate,
            deviceAssignment.ReturnDate,
            deviceAssignment.ConditionOnReturn
        );
    }
}
