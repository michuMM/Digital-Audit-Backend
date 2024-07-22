

using DotNetBoilerplate.Core.Employees.Exceptions;

namespace DotNetBoilerplate.Core.Employees;

public class Employee
{
    private Employee()
    {
    }

    public Guid Id { get; private set; }
    
    public Guid OrganizationId { get; private set; }
    
    public string FirstName{ get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public static Employee NewEmployee(
        Guid organizationid, 
        string firstName, 
        string lastName, 
        string email, 
        string phone)
    {
        return new Employee
        {
            Id = Guid.NewGuid(),
            OrganizationId = organizationid,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Phone = phone
        };
    }

    public void Update(string firstName, string lastName, string email, string phone, bool emailIsUnique, bool phoneIsUnique) 
    { 
         if (!emailIsUnique)
         {
            throw new EmployeeEmailIsNotUniqueException();
         }
         
         if (!phoneIsUnique)
         {
            throw new EmployeePhoneNumberIsNotUniqueException();
         }

         FirstName = firstName;
         LastName = lastName;
         Email = email;
         Phone = phone;
    }
}
