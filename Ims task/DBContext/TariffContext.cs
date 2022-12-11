using Ims_task.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Ims_task.DBContext
{
    public class TariffContext: DbContext
    {
        public TariffContext(DbContextOptions<TariffContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TariffMaster>()
                .HasOne(m => m.details)
                .WithOne(d => d.master)
                .HasForeignKey<TariffDetails>(d => d.tariffId);
        }

        public DbSet<TariffMaster> TariffMaster { get; set; }
        public DbSet<TariffDetails> TariffDetails { get; set; }
    }
}
