using Microsoft.EntityFrameworkCore;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Domain;
using TalentForge.Domain.Common;

namespace TalentForge.Persistence
{
    public class TalentForgeDbContext : DbContext, ITalentForgeDbContext
    {
        public TalentForgeDbContext(DbContextOptions<TalentForgeDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TalentForgeDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseObject>())
            {
                entry.Entity.ModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added) 
                    entry.Entity.CreatedDate = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Domain.Task> Tasks { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> Applications { get; set; }
    }
}
