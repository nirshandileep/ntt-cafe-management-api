using Microsoft.EntityFrameworkCore;

namespace NTT.CafeManagement.Infrastructure.Database;

public interface IDbContext
{
    DbContext Instance { get; }
}
