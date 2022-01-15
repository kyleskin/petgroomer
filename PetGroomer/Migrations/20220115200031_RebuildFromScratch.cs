using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetGroomer.Migrations
{
    public partial class RebuildFromScratch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Salons",
                columns: table => new
                {
                    SalonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salons", x => x.SalonId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Groomers",
                columns: table => new
                {
                    GroomerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SalonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groomers", x => x.GroomerId);
                    table.ForeignKey(
                        name: "FK_Groomers_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "SalonId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SalonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Owners_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "SalonId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PetId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GroomerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Groomers_GroomerId",
                        column: x => x.GroomerId,
                        principalTable: "Groomers",
                        principalColumn: "GroomerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    PetId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.PetId);
                    table.ForeignKey(
                        name: "FK_Pets_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Salons",
                columns: new[] { "SalonId", "Name" },
                values: new object[] { new Guid("06dae702-94eb-4c03-978c-deccdf1b8031"), "Snips & Snails & Puppy Dog Tails" });

            migrationBuilder.InsertData(
                table: "Salons",
                columns: new[] { "SalonId", "Name" },
                values: new object[] { new Guid("ef85d02e-b920-4f74-9df0-9072e552a7a2"), "Best Pet Groomer" });

            migrationBuilder.InsertData(
                table: "Groomers",
                columns: new[] { "GroomerId", "FirstName", "LastName", "SalonId" },
                values: new object[,]
                {
                    { new Guid("aedbe5cc-bd60-4f5b-9a66-69a146e78698"), "Amy", "Johnson", new Guid("ef85d02e-b920-4f74-9df0-9072e552a7a2") },
                    { new Guid("ecb770fa-b1f3-4a1d-afec-f9d20893fe07"), "Jane", "Doe", new Guid("06dae702-94eb-4c03-978c-deccdf1b8031") },
                    { new Guid("fd3efa8f-c484-46c8-97e7-de38df002432"), "John", "Smith", new Guid("ef85d02e-b920-4f74-9df0-9072e552a7a2") }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "Email", "FirstName", "LastName", "Phone", "SalonId" },
                values: new object[,]
                {
                    { new Guid("4f0528d3-5f4b-4333-9801-d31ae2888d88"), "kathleen@email.com", "Kathleen", "Skinner", "7032826710", new Guid("ef85d02e-b920-4f74-9df0-9072e552a7a2") },
                    { new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2"), "kyle@email.com", "Kyle", "Skinner", "7203832311", new Guid("ef85d02e-b920-4f74-9df0-9072e552a7a2") }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "DateTime", "Details", "Duration", "GroomerId", "PetId" },
                values: new object[,]
                {
                    { new Guid("70c451a9-d7e0-4aa5-bf19-40ea1d86250c"), new DateTime(2022, 1, 15, 13, 0, 31, 72, DateTimeKind.Local).AddTicks(2130), "matted and lice", 45, new Guid("aedbe5cc-bd60-4f5b-9a66-69a146e78698"), new Guid("43acbff7-92d5-47e7-94db-89195c296e3f") },
                    { new Guid("f184f942-063e-48a7-aa63-d926cbf3500f"), new DateTime(2022, 1, 15, 13, 0, 31, 72, DateTimeKind.Local).AddTicks(2100), "short cut and shampoo", 30, new Guid("fd3efa8f-c484-46c8-97e7-de38df002432"), new Guid("db5ca57b-3979-40f2-9999-6afae0304bec") }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "PetId", "Name", "Notes", "OwnerId", "Type" },
                values: new object[,]
                {
                    { new Guid("43acbff7-92d5-47e7-94db-89195c296e3f"), "Stormy", "ugliest dog", new Guid("4f0528d3-5f4b-4333-9801-d31ae2888d88"), 0 },
                    { new Guid("8ce9498f-c7ba-49a7-8236-6aa43dc97250"), "Rosie", "annoying", new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2"), 0 },
                    { new Guid("ce005075-ff5c-4f25-9f63-2ac00673abe6"), "Mittens", null, new Guid("4f0528d3-5f4b-4333-9801-d31ae2888d88"), 1 },
                    { new Guid("db5ca57b-3979-40f2-9999-6afae0304bec"), "Fozzie", "Energetic pet", new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2"), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_GroomerId",
                table: "Appointments",
                column: "GroomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Groomers_SalonId",
                table: "Groomers",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_SalonId",
                table: "Owners",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_OwnerId",
                table: "Pets",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Groomers");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Salons");
        }
    }
}
