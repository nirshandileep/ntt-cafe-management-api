using NTT.CafeManagement.Domain.Base;

namespace NTT.CafeManagement.Domain.Models;

public class EmployeeCafeAssignment : Entity
{
    public string EmployeeId { get; private set; }
    public Employee Employee { get; private set; }
    public Guid CafeId { get; private set; }
    public Cafe Cafe { get; private set; }
    public DateTime StartDate { get; private set; }

    public static EmployeeCafeAssignment Create(string employeeId, Guid cafeId)
    {
        return new EmployeeCafeAssignment
        {
            EmployeeId = employeeId,
            CafeId = cafeId,
            StartDate = DateTime.UtcNow
        };
    }
}
