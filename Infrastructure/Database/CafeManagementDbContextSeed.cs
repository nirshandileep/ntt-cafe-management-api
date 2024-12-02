using Microsoft.EntityFrameworkCore;

namespace NTT.CafeManagement.Infrastructure.Database;

public class CafeManagementDbContextSeed
{
    public async Task SeedAsync(CafeManagementDbContext context)
    {
        using (context)
        {
            await context.Database.MigrateAsync();
        }
    }
}
