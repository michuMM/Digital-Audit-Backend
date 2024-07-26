using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public EmployeeDto(Guid id, Guid organizationId, string firstName, string lastName, string email, string phone)
        {
            Id=id;
            OrganizationId=organizationId;
            FirstName=firstName;
            LastName=lastName;
            Email=email;
            Phone=phone;
        }

        public Guid Id { get; private set; }

        public Guid OrganizationId { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
