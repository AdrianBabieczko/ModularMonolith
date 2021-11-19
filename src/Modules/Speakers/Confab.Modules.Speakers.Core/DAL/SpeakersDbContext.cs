using Confab.Modules.Speakers.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Speakers.Core.DAL
{
    internal class SpeakersDbContext: DbContext
    {
        public DbSet<Speaker> Speaker { get; set; }

        public SpeakersDbContext(DbContextOptions<SpeakersDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("speakers");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}