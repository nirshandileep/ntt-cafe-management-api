using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.CafeManagement.Domain.Models;

namespace NTT.CafeManagement.Infrastructure.Database.SchemaConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EmployeeCode).HasMaxLength(9).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(8).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.HasMany(x => x.EmployeeCafeAssignments).WithOne(x => x.Employee).HasForeignKey(x => x.EmployeeId);
        }
    }
}
