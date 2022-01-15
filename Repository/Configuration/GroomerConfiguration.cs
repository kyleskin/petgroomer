using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class GroomerConfiguration : IEntityTypeConfiguration<Groomer>
    {
        public void Configure(EntityTypeBuilder<Groomer> builder)
        {
            builder.HasData
            (
                new Groomer
                {
                    Id = new Guid("fd3efa8f-c484-46c8-97e7-de38df002432"),
                    FirstName = "John",
                    LastName = "Smith",
                    SalonId = new Guid("ef85d02e-b920-4f74-9df0-9072e552a7a2")
                },
                new Groomer
                {
                    Id = new Guid("aedbe5cc-bd60-4f5b-9a66-69a146e78698"),
                    FirstName = "Amy",
                    LastName = "Johnson",
                    SalonId = new Guid("ef85d02e-b920-4f74-9df0-9072e552a7a2")
                },
                new Groomer
                {
                    Id = new Guid("ecb770fa-b1f3-4a1d-afec-f9d20893fe07"),
                    FirstName = "Jane",
                    LastName = "Doe",
                    SalonId = new Guid("06dae702-94eb-4c03-978c-deccdf1b8031")
                }
            );
        }
    }
}