using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetGroomer.Migrations
{
    public partial class AddCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: new Guid("70c451a9-d7e0-4aa5-bf19-40ea1d86250c"),
                column: "DateTime",
                value: new DateTime(2022, 1, 4, 21, 24, 24, 962, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: new Guid("f184f942-063e-48a7-aa63-d926cbf3500f"),
                column: "DateTime",
                value: new DateTime(2022, 1, 4, 21, 24, 24, 962, DateTimeKind.Local).AddTicks(2430));

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "PetId", "Name", "Notes", "OwnerId", "Type" },
                values: new object[] { new Guid("ce005075-ff5c-4f25-9f63-2ac00673abe6"), "Mittens", null, new Guid("4f0528d3-5f4b-4333-9801-d31ae2888d88"), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: new Guid("ce005075-ff5c-4f25-9f63-2ac00673abe6"));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: new Guid("70c451a9-d7e0-4aa5-bf19-40ea1d86250c"),
                column: "DateTime",
                value: new DateTime(2022, 1, 4, 21, 12, 23, 858, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: new Guid("f184f942-063e-48a7-aa63-d926cbf3500f"),
                column: "DateTime",
                value: new DateTime(2022, 1, 4, 21, 12, 23, 858, DateTimeKind.Local).AddTicks(3540));
        }
    }
}
