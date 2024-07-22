using DotNetBoilerplate.Core.Organizations.Exceptions;
using DotNetBoilerplate.Core.Users;

namespace DotNetBoilerplate.Core.Organizations;

public class Organization
{
    private Organization()
    {
    }

    public Guid Id { get; private set; }

    public string Name { get; set; } //zmiana na public set, bo UpdateAsync musi móc zmieniać nazwe

    public UserId OwnerId { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public static Organization Create(
        string name,
        Guid ownerId,
        DateTimeOffset now,
        bool nameIsUnique
    )
    {
        if (!nameIsUnique)
            throw new OrganizationNameIsNotUniqueException();

        return new Organization
        {
            Id = Guid.NewGuid(),
            Name = name,
            OwnerId = ownerId,
            CreatedAt = now
        };
    }

    public void Update(string name, bool nameIsUnique)
    {
        if (!nameIsUnique)
            throw new OrganizationNameIsNotUniqueException();

        Name = name;
    }
}