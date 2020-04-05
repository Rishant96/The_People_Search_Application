﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeopleSearchApp.Contexts;

namespace PeopleSearchApp.Migrations
{
    [DbContext(typeof(PersonDbContext))]
    partial class PersonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PeopleSearchApp.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("Date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PathToAvatar")
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("PersonAddressId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonAddressId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DOB = new DateTime(1982, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "David",
                            IsFavorite = false,
                            LastName = "Johnson",
                            PersonAddressId = 1
                        },
                        new
                        {
                            Id = 2,
                            DOB = new DateTime(1991, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ashley",
                            IsFavorite = false,
                            LastName = "Thompson",
                            PersonAddressId = 2
                        },
                        new
                        {
                            Id = 3,
                            DOB = new DateTime(1994, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Varun",
                            IsFavorite = false,
                            LastName = "Dutt",
                            PersonAddressId = 3
                        });
                });

            modelBuilder.Entity("PeopleSearchApp.Models.PersonAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Line2")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("PersonAddress");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Charlotte",
                            Country = "United States",
                            Line1 = "1539, Bonnie Rd",
                            State = "North Carolina",
                            ZipCode = "28213"
                        },
                        new
                        {
                            Id = 2,
                            City = "Charlotte",
                            Country = "United States",
                            Line1 = "1624 C, Arlyn Cir",
                            Line2 = "Margie Ann Rd",
                            State = "North Carolina",
                            ZipCode = "28213"
                        },
                        new
                        {
                            Id = 3,
                            City = "Gurugram",
                            Country = "India",
                            Line1 = "House No. 259, Sector 9A",
                            State = "Haryana",
                            ZipCode = "122001"
                        });
                });

            modelBuilder.Entity("PeopleSearchApp.Models.PersonInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Interest")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonInterest");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Interest = "Reading Novels",
                            PersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            Interest = "Swimming",
                            PersonId = 1
                        },
                        new
                        {
                            Id = 3,
                            Interest = "Camping",
                            PersonId = 2
                        },
                        new
                        {
                            Id = 4,
                            Interest = "Listening to Music",
                            PersonId = 2
                        },
                        new
                        {
                            Id = 5,
                            Interest = "Cooking",
                            PersonId = 2
                        },
                        new
                        {
                            Id = 6,
                            Interest = "Playing Video Games",
                            PersonId = 3
                        },
                        new
                        {
                            Id = 7,
                            Interest = "Playing Guitar",
                            PersonId = 3
                        });
                });

            modelBuilder.Entity("PeopleSearchApp.Models.Person", b =>
                {
                    b.HasOne("PeopleSearchApp.Models.PersonAddress", "Address")
                        .WithMany()
                        .HasForeignKey("PersonAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PeopleSearchApp.Models.PersonInterest", b =>
                {
                    b.HasOne("PeopleSearchApp.Models.Person", null)
                        .WithMany("Interests")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
