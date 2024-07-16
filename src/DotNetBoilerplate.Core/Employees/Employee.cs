

namespace DotNetBoilerplate.Core.Employees;

public class Employee
{
    private Employee()
    {
    }

    public Guid Id { get; private set; }

    public string First_name { get; set; }

    public string Last_name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public static Employee NewEmployee(string first_name, string last_name, string email, string phone)
    {
        return new Employee
        {
            Id = Guid.NewGuid(),
            First_name = first_name,
            Last_name = last_name,
            Email = email,
            Phone = phone
        };
    }

}
