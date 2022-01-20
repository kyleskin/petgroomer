using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetGroomer.Migrations
{
    public partial class AddedRolestoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: new Guid("70c451a9-d7e0-4aa5-bf19-40ea1d86250c"),
                column: "DateTime",
                value: new DateTime(2022, 1, 19, 17, 27, 52, 113, DateTimeKind.Local).AddTicks(4360));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: new Guid("f184f942-063e-48a7-aa63-d926cbf3500f"),
                column: "DateTime",
                value: new DateTime(2022, 1, 19, 17, 27, 52, 113, DateTimeKind.Local).AddTicks(4330));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: new Guid("70c451a9-d7e0-4aa5-bf19-40ea1d86250c"),
                column: "DateTime",
                value: new DateTime(2022, 1, 19, 17, 21, 26, 957, DateTimeKind.Local).AddTicks(5590));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: new Guid("f184f942-063e-48a7-aa63-d926cbf3500f"),
                column: "DateTime",
                value: new DateTime(2022, 1, 19, 17, 21, 26, 957, DateTimeKind.Local).AddTicks(5560));
        }
    }
}
