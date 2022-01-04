using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class PetTypeConfiguration : IEntityTypeConfiguration<PetType>
    {
        public void Configure(EntityTypeBuilder<PetType> builder)
        {
            builder.HasData
            (
                new PetType
                {
                    Id = new Guid("c70bb081-cf3b-4e35-ae44-abb10c4c582a"),
                    Type = "Dog"
                },
                new PetType
                {
                    Id = new Guid("ca738c4a-3538-48f4-b7ce-04f8e2ee45f6"),
                    Type = "Cat"
                }
            );
        }
    }
}

