namespace DotNetBoilerplate.Application.DeviceAssignments
{
    public sealed record DeviceAssignmentDto
    {
        public DeviceAssignmentDto(
            Guid id,
            Guid deviceId, 
            Guid employeeId, 
            DateTimeOffset issueDate,
            DateTimeOffset returnDate,
            string conditionOnReturn
            )
        {
            Id = id;
            DeviceId = deviceId;
            EmployeeId = employeeId;
            IssueDate = issueDate;
            ReturnDate = returnDate;
            ConditionOnReturn = conditionOnReturn;
            
        }

        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset ReturnDate { get; set; }
        public string ConditionOnReturn { get; set; }
    }
}


