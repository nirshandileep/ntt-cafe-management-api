using NTT.CafeManagement.Domain.Base;

namespace NTT.CafeManagement.Domain.Models;

public class Cafe : Entity
{
    public Guid Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Location { get; private set; }
    public string? LogoUrl { get; private set; }
    public List<EmployeeCafeAssignment>? EmployeeCafeAssignments { get; private set; }

    public static Cafe CreateNewCafe(string name)
    {
        return new Cafe
        {
            Name = name
        };
    }

    public Cafe SetDescription(string description)
    {
        Description = description;
        return this;
    }

    public Cafe SetLogoUrl(string logoUrl)
    {
        LogoUrl = logoUrl;
        return this;
    }

    public Cafe SetLocation(string location)
    {
        Location = location;
        return this;
    }
}
