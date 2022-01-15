using System;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasData
            (
                new Pet
                {
                    Id = new Guid("db5ca57b-3979-40f2-9999-6afae0304bec"),
                    Name = "Fozzie",
                    Notes = "Energetic pet",
                    Type = PetTypes.Dog,
                    OwnerId = new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2") // Kyle
                },
                new Pet
                {
                    Id = new Guid("8ce9498f-c7ba-49a7-8236-6aa43dc97250"),
                    Name = "Rosie",
                    Notes = "annoying",
                    Type = PetTypes.Dog,
                    OwnerId = new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2") // Kyle
                },
                new Pet
                {
                    Id = new Guid("43acbff7-92d5-47e7-94db-89195c296e3f"),
                    Name = "Stormy",
                    Notes = "ugliest dog",
                    Type = PetTypes.Dog,
                    OwnerId = new Guid("4f0528d3-5f4b-4333-9801-d31ae2888d88") // Kathleen
                },
                new Pet
                {
                    Id = new Guid("ce005075-ff5c-4f25-9f63-2ac00673abe6"),
                    Name = "Mittens",
                    Type = PetTypes.Cat,
                    OwnerId = new Guid("4f0528d3-5f4b-4333-9801-d31ae2888d88") // Kathleen
                }
            );
        }
    }
}

