using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
	{
        public RepositoryContext(DbContextOptions options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new SalonConfiguration());
			modelBuilder.ApplyConfiguration(new GroomerConfiguration());
			modelBuilder.ApplyConfiguration(new OwnerConfiguration());
			modelBuilder.ApplyConfiguration(new PetConfiguration());
			modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        }

		public DbSet<Owner>? Owners { get; set; }
		public DbSet<Pet>? Pets { get; set; }
		public DbSet<Appointment>? Appointments { get; set; }
		public DbSet<Salon>? Salons { get; set; }
		public DbSet<Groomer>? Groomers { get; set; }
	}
}

