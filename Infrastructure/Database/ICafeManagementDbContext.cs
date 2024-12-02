using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NTT.CafeManagement.Infrastructure.Database
{
    public interface ICafeManagementDbContext : IDbContext
    {
        DbSet<TEntity> DbSet<TEntity>() where TEntity : class;
        Task<EntityEntry<TEntity>> AddEntityAsync<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> RemoveEntity<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
