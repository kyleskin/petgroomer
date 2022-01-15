using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
	public class RepositoryContext : DbContext
	{
        public RepositoryContext(DbContextOptions options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

