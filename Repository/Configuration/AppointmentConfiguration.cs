using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasData
            (
                new Appointment
                {
                    Id = new Guid("f184f942-063e-48a7-aa63-d926cbf3500f"),
                    DateTime = DateTime.Now,
                    Duration = 30,
                    Details = "short cut and shampoo",
                    PetId = new Guid("db5ca57b-3979-40f2-9999-6afae0304bec")
                },
                new Appointment
                {
                    Id = new Guid("70c451a9-d7e0-4aa5-bf19-40ea1d86250c"),
                    DateTime = DateTime.Now,
                    Duration = 45,
                    Details = "matted and lice",
                    PetId = new Guid("43acbff7-92d5-47e7-94db-89195c296e3f")
                }
            ); ;
        }
    }
}

