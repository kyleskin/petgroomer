using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetGroomer.Migrations
{
    public partial class PetTypesEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetTypes_PetTypeId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "PetTypes");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetTypeId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetTypeId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Pets");

            migrationBuilder.AddColumn<Guid>(
                name: "PetTypeId",
                table: "Pets",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "PetTypes",
                columns: table => new
                {
                    PetTypeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetTypes", x => x.PetTypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: new Guid("70c451a9-d7e0-4aa5-bf19-40ea1d86250c"),
                column: "DateTime",
                value: new DateTime(2022, 1, 3, 20, 46, 20, 975, DateTimeKind.Local).AddTicks(6800));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: new Guid("f184f942-063e-48a7-aa63-d926cbf3500f"),
                column: "DateTime",
                value: new DateTime(2022, 1, 3, 20, 46, 20, 975, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.InsertData(
                table: "PetTypes",
                columns: new[] { "PetTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("c70bb081-cf3b-4e35-ae44-abb10c4c582a"), "Dog" },
                    { new Guid("ca738c4a-3538-48f4-b7ce-04f8e2ee45f6"), "Cat" }
                });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: new Guid("43acbff7-92d5-47e7-94db-89195c296e3f"),
                column: "PetTypeId",
                value: new Guid("c70bb081-cf3b-4e35-ae44-abb10c4c582a"));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: new Guid("8ce9498f-c7ba-49a7-8236-6aa43dc97250"),
                column: "PetTypeId",
                value: new Guid("c70bb081-cf3b-4e35-ae44-abb10c4c582a"));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: new Guid("db5ca57b-3979-40f2-9999-6afae0304bec"),
                column: "PetTypeId",
                value: new Guid("c70bb081-cf3b-4e35-ae44-abb10c4c582a"));

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetTypeId",
                table: "Pets",
                column: "PetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetTypes_PetTypeId",
                table: "Pets",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "PetTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
