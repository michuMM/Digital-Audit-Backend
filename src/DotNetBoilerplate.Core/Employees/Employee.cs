

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
        string first_name, 
        string last_name, 
        string email, 
        string phone)
    {
        return new Employee
        {
            Id = Guid.NewGuid(),
            OrganizationId = organizationid,
            FirstName = first_name,
            LastName = last_name,
            Email = email,
            Phone = phone
        };
    }

}
