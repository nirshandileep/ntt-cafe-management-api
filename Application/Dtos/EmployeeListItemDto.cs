using NTT.CafeManagement.Domain.Enum;

namespace NTT.CafeManagement.Application.Dtos
{
    public class EmployeeListItemDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email_Address { get; set; }
        public string Phone_Number { get; set; }
        public int Days_Worked { get; set; }
        public string Cafe { get; set; }
    }
}
