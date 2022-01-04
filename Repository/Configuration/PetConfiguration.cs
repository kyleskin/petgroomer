using System;
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
                    PetTypeId = new Guid("c70bb081-cf3b-4e35-ae44-abb10c4c582a"),
                    OwnerId = new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2")
                },
                new Pet
                {
                    Id = new Guid("8ce9498f-c7ba-49a7-8236-6aa43dc97250"),
                    Name = "Rosie",
                    Notes = "annoying",
                    PetTypeId = new Guid("c70bb081-cf3b-4e35-ae44-abb10c4c582a"),
                    OwnerId = new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2")
                },
                new Pet
                {
                    Id = new Guid("43acbff7-92d5-47e7-94db-89195c296e3f"),
                    Name = "Stormy",
                    Notes = "ugliest dog",
                    PetTypeId = new Guid("c70bb081-cf3b-4e35-ae44-abb10c4c582a"),
                    OwnerId = new Guid("4f0528d3-5f4b-4333-9801-d31ae2888d88")
                }
            );
        }
    }
}

