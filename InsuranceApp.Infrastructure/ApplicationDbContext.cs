using InsuranceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace InsuranceApp.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<InsuredPerson> InsuredPersons => Set<InsuredPerson>();
        public DbSet<Insurance> Insurances => Set<Insurance>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Insurance>()
                .Property(i => i.InsuranceType)
                .HasConversion<string>();

            modelBuilder.Entity<Insurance>()
                .Property(i => i.Amount)
                .HasPrecision(14, 2);
        }
    }
}
