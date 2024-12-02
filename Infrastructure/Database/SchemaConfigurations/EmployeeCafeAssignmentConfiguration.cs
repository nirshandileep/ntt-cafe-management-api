using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.CafeManagement.Domain.Models;

namespace NTT.CafeManagement.Infrastructure.Database.SchemaConfigurations;

public class EmployeeCafeAssignmentConfiguration : IEntityTypeConfiguration<EmployeeCafeAssignment>
{
    public void Configure(EntityTypeBuilder<EmployeeCafeAssignment> builder)
    {
        builder.ToTable("employee_cafe_assignments");
        builder.HasKey(x => new { x.EmployeeId, x.CafeId });
        builder.Property(x => x.StartDate).IsRequired();
        builder.HasOne(x => x.Employee).WithMany(x => x.EmployeeCafeAssignments).HasForeignKey(x => x.EmployeeId);
        builder.HasOne(x => x.Cafe).WithMany(x => x.EmployeeCafeAssignments).HasForeignKey(x => x.CafeId);
    }
}
