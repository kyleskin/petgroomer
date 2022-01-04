using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetGroomer.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "DateTime", "Details", "Duration", "PetId" },
                values: new object[,]
                {
                    { new Guid("70c451a9-d7e0-4aa5-bf19-40ea1d86250c"), new DateTime(2022, 1, 3, 20, 46, 20, 975, DateTimeKind.Local).AddTicks(6800), "matted and lice", 45, new Guid("43acbff7-92d5-47e7-94db-89195c296e3f") },
                    { new Guid("f184f942-063e-48a7-aa63-d926cbf3500f"), new DateTime(2022, 1, 3, 20, 46, 20, 975, DateTimeKind.Local).AddTicks(6760), "short cut and shampoo", 30, new Guid("db5ca57b-3979-40f2-9999-6afae0304bec") }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("4f0528d3-5f4b-4333-9801-d31ae2888d88"), "kathleen@email.com", "Kathleen", "Skinner", "7032826710" },
                    { new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2"), "kyle@email.com", "Kyle", "Skinner", "7203832311" }
                });

            migrationBuilder.InsertData(
                table: "PetTypes",
                columns: new[] { "PetTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("c70bb081-cf3b-4e35-ae44-abb10c4c582a"), "Dog" },
                    { new Guid("ca738c4a-3538-48f4-b7ce-04f8e2ee45f6"), "Cat" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "PetId", "Name", "Notes", "OwnerId", "PetTypeId" },
                values: new object[] { new Guid("43acbff7-92d5-47e7-94db-89195c296e3f"), "Stormy", "ugliest dog", new Guid("4f0528d3-5f4b-4333-9801-d31ae2888d88"), new Guid("c70bb081-cf3b-4e35-ae44-abb10c4c582a") });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "PetId", "Name", "Notes", "OwnerId", "PetTypeId" },
                values: new object[] { new Guid("8ce9498f-c7ba-49a7-8236-6aa43dc97250"), "Rosie", "annoying", new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2"), new Guid("c70bb081-cf3b-4e35-ae44-abb10c4c582a") });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "PetId", "Name", "Notes", "OwnerId", "PetTypeId" },
                values: new object[] { new Guid("db5ca57b-3979-40f2-9999-6afae0304bec"), "Fozzie", "Energetic pet", new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2"), new Guid("c70bb081-cf3b-4e35-ae44-abb10c4c582a") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: new Guid("70c451a9-d7e0-4aa5-bf19-40ea1d86250c"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: new Guid("f184f942-063e-48a7-aa63-d926cbf3500f"));

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "PetTypeId",
                keyValue: new Guid("ca738c4a-3538-48f4-b7ce-04f8e2ee45f6"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: new Guid("43acbff7-92d5-47e7-94db-89195c296e3f"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: new Guid("8ce9498f-c7ba-49a7-8236-6aa43dc97250"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: new Guid("db5ca57b-3979-40f2-9999-6afae0304bec"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: new Guid("4f0528d3-5f4b-4333-9801-d31ae2888d88"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2"));

            migrationBuilder.DeleteData(
                table: "PetTypes",
                keyColumn: "PetTypeId",
                keyValue: new Guid("c70bb081-cf3b-4e35-ae44-abb10c4c582a"));
        }
    }
}
