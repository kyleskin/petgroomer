using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class SalonConfiguration : IEntityTypeConfiguration<Salon>
    {
        public void Configure(EntityTypeBuilder<Salon> builder)
        {
            builder.HasData
            (
                new Salon
                {
                    Id = new Guid("ef85d02e-b920-4f74-9df0-9072e552a7a2"),
                    Name = "Best Pet Groomer"
                },
                new Salon
                {
                    Id = new Guid("06dae702-94eb-4c03-978c-deccdf1b8031"),
                    Name = "Snips & Snails & Puppy Dog Tails"
                }
            );
        }
    }
}