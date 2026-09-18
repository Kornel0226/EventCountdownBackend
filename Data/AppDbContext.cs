using EventCountdownBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EventCountdownBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Event> Events => Set<Event>();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Event>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    // Add the current date when entity is created

                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {   
                    // When entity is updated 

                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Enforce physical location completeness at the database level:
            // - Online events (IsOnline == true) do not require location data.
            // - In-person events (IsOnline == false) MUST provide Country, City, Address and ZipCode.

            modelBuilder.Entity<Event>(
                entity => {
                    entity.ToTable(t => t.HasCheckConstraint(
                        "CK_Event_PhysicalLocationRequired",
                        "([IsOnline] = 1) OR ([City] IS NOT NULL AND [Address] IS NOT NULL AND [Country] IS NOT NULL AND [ZipCode] IS NOT NULL)"
                        ));
                }
             );

        }
    }
}
