﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace PetGroomer.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220120002752_AddedRolestoDb")]
    partial class AddedRolestoDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.Models.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("AppointmentId");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Details")
                        .HasColumnType("longtext");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<Guid>("GroomerId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PetId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("GroomerId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f184f942-063e-48a7-aa63-d926cbf3500f"),
                            DateTime = new DateTime(2022, 1, 19, 17, 27, 52, 113, DateTimeKind.Local).AddTicks(4330),
                            Details = "short cut and shampoo",
                            Duration = 30,
                            GroomerId = new Guid("fd3efa8f-c484-46c8-97e7-de38df002432"),
                            PetId = new Guid("db5ca57b-3979-40f2-9999-6afae0304bec")
                        },
                        new
                        {
                            Id = new Guid("70c451a9-d7e0-4aa5-bf19-40ea1d86250c"),
                            DateTime = new DateTime(2022, 1, 19, 17, 27, 52, 113, DateTimeKind.Local).AddTicks(4360),
                            Details = "matted and lice",
                            Duration = 45,
                            GroomerId = new Guid("aedbe5cc-bd60-4f5b-9a66-69a146e78698"),
                            PetId = new Guid("43acbff7-92d5-47e7-94db-89195c296e3f")
                        });
                });

            modelBuilder.Entity("Entities.Models.Groomer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("GroomerId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("SalonId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("SalonId");

                    b.ToTable("Groomers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fd3efa8f-c484-46c8-97e7-de38df002432"),
                            FirstName = "John",
                            LastName = "Smith",
                            SalonId = new Guid("ef85d02e-b920-4f74-9df0-9072e552a7a2")
                        },
                        new
                        {
                            Id = new Guid("aedbe5cc-bd60-4f5b-9a66-69a146e78698"),
                            FirstName = "Amy",
                            LastName = "Johnson",
                            SalonId = new Guid("ef85d02e-b920-4f74-9df0-9072e552a7a2")
                        },
                        new
                        {
                            Id = new Guid("ecb770fa-b1f3-4a1d-afec-f9d20893fe07"),
                            FirstName = "Jane",
                            LastName = "Doe",
                            SalonId = new Guid("06dae702-94eb-4c03-978c-deccdf1b8031")
                        });
                });

            modelBuilder.Entity("Entities.Models.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("OwnerId");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("SalonId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("SalonId");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2"),
                            Email = "kyle@email.com",
                            FirstName = "Kyle",
                            LastName = "Skinner",
                            Phone = "7203832311",
                            SalonId = new Guid("ef85d02e-b920-4f74-9df0-9072e552a7a2")
                        },
                        new
                        {
                            Id = new Guid("4f0528d3-5f4b-4333-9801-d31ae2888d88"),
                            Email = "kathleen@email.com",
                            FirstName = "Kathleen",
                            LastName = "Skinner",
                            Phone = "7032826710",
                            SalonId = new Guid("ef85d02e-b920-4f74-9df0-9072e552a7a2")
                        });
                });

            modelBuilder.Entity("Entities.Models.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("PetId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Pets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("db5ca57b-3979-40f2-9999-6afae0304bec"),
                            Name = "Fozzie",
                            Notes = "Energetic pet",
                            OwnerId = new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2"),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("8ce9498f-c7ba-49a7-8236-6aa43dc97250"),
                            Name = "Rosie",
                            Notes = "annoying",
                            OwnerId = new Guid("f17c14d9-425b-46c6-86b4-2d8478f16fd2"),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("43acbff7-92d5-47e7-94db-89195c296e3f"),
                            Name = "Stormy",
                            Notes = "ugliest dog",
                            OwnerId = new Guid("4f0528d3-5f4b-4333-9801-d31ae2888d88"),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("ce005075-ff5c-4f25-9f63-2ac00673abe6"),
                            Name = "Mittens",
                            OwnerId = new Guid("4f0528d3-5f4b-4333-9801-d31ae2888d88"),
                            Type = 1
                        });
                });

            modelBuilder.Entity("Entities.Models.Salon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("SalonId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Salons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ef85d02e-b920-4f74-9df0-9072e552a7a2"),
                            Name = "Best Pet Groomer"
                        },
                        new
                        {
                            Id = new Guid("06dae702-94eb-4c03-978c-deccdf1b8031"),
                            Name = "Snips & Snails & Puppy Dog Tails"
                        });
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Appointment", b =>
                {
                    b.HasOne("Entities.Models.Groomer", null)
                        .WithMany("Appointments")
                        .HasForeignKey("GroomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Groomer", b =>
                {
                    b.HasOne("Entities.Models.Salon", null)
                        .WithMany("Groomers")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Owner", b =>
                {
                    b.HasOne("Entities.Models.Salon", null)
                        .WithMany("Owners")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Pet", b =>
                {
                    b.HasOne("Entities.Models.Owner", null)
                        .WithMany("Pets")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Groomer", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Entities.Models.Owner", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Entities.Models.Salon", b =>
                {
                    b.Navigation("Groomers");

                    b.Navigation("Owners");
                });
#pragma warning restore 612, 618
        }
    }
}
