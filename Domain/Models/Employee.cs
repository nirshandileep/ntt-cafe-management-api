using NTT.CafeManagement.Domain.Base;
using NTT.CafeManagement.Domain.Enum;

namespace NTT.CafeManagement.Domain.Models
{
    public class Employee : Entity
    {
        public Guid Id { get; }
        public string EmployeeCode { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Gender Gender { get; private set; }
        public List<EmployeeCafeAssignment> EmployeeCafeAssignments { get; set; }

        public static Employee Create(string employeeCode)
        {
            return new Employee
            {
                EmployeeCode = employeeCode
            };
        }

        public Employee SetName(string name)
        {
            Name = name;
            return this;
        }

        public Employee SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public Employee SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }

        public Employee SetGender(Gender gender)
        {
            Gender = gender;
            return this;
        }

        public Employee AddCafeAssignment(Guid cafeId)
        {
            EmployeeCafeAssignments ??= [];
            var cafeAssigmment = EmployeeCafeAssignment.Create(Id, cafeId);
            EmployeeCafeAssignments.Add(cafeAssigmment);
            return this;
        }
    }
}