using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
	public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
	{
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasData
            (
                new Owner
                {
                    Id = new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2"),
                    FirstName = "Kyle",
                    LastName = "Skinner",
                    Email = "kyle@email.com",
                    Phone = "7203832311",
                },
                new Owner
                {
                    Id = new Guid("4f0528d3-5f4b-4333-9801-d31ae2888d88"),
                    FirstName = "Kathleen",
                    LastName = "Skinner",
                    Email = "kathleen@email.com",
                    Phone = "7032826710"
                }
            );
        }
    }
}

