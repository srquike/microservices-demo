using MicroservicesDemo.Domain;
using MicroservicesDemo.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesDemo.Infrastructure.Persistence
{
    public class UsersDbContext : DbContext
    {

        public virtual DbSet<UserEntity> Users { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.Entity.LastModifiedDate = DateTime.UtcNow;
                        item.Entity.LastModifiedBy = $"{Environment.MachineName}: {Environment.UserName}";
                        break;
                    case EntityState.Added:
                        item.Entity.CreatedDate = DateTime.UtcNow;
                        item.Entity.CreatedBy = $"{Environment.MachineName}: {Environment.UserName}";
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
