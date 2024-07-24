

namespace DotNetBoilerplate.Application.Employees
{
    public sealed record EmployeeDto
    {
        public EmployeeDto(string firstName, string lastName, string email, string phone)
        {
            FirstName=firstName;
            LastName=lastName;
            Email=email;
            Phone=phone;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
