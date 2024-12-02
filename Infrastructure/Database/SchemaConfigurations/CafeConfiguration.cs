using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.CafeManagement.Domain.Models;

namespace NTT.CafeManagement.Infrastructure.Database.SchemaConfigurations
{
    public class CafeConfiguration : IEntityTypeConfiguration<Cafe>
    {
        public void Configure(EntityTypeBuilder<Cafe> builder)
        {
            builder.ToTable("cafes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Location).IsRequired();
            builder.HasMany(x => x.EmployeeCafeAssignments).WithOne(x => x.Cafe).HasForeignKey(x => x.CafeId);
        }
    }
}
