﻿// <auto-generated />
using System;
using CourseLibraryAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseLibraryAPI.Migrations
{
    [DbContext(typeof(CourseLibraryDbContext))]
    [Migration("20231015120641_ExampleDataAdded")]
    partial class ExampleDataAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseLibraryAPI.Models.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MainCategory")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            DateOfBirth = new DateTime(1980, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Berry",
                            Lastname = "Griffin Beak Eldritch",
                            MainCategory = "Ships"
                        },
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            DateOfBirth = new DateTime(1978, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Nancy",
                            Lastname = "Swashbuckler Rye",
                            MainCategory = "Rum"
                        },
                        new
                        {
                            Id = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            DateOfBirth = new DateTime(1957, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Eli",
                            Lastname = "Ivory Bones Sweet",
                            MainCategory = "Singing"
                        },
                        new
                        {
                            Id = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            DateOfBirth = new DateTime(1957, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Arnold",
                            Lastname = "The Unseen Stafford",
                            MainCategory = "Singing"
                        },
                        new
                        {
                            Id = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            DateOfBirth = new DateTime(1956, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Seabury",
                            Lastname = "Toxic Reyson",
                            MainCategory = "Maps"
                        },
                        new
                        {
                            Id = new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                            DateOfBirth = new DateTime(1981, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Rutherford",
                            Lastname = "Fearless Cloven",
                            MainCategory = "General debauchery"
                        },
                        new
                        {
                            Id = new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                            DateOfBirth = new DateTime(1982, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Atherton",
                            Lastname = "Crow Ridley",
                            MainCategory = "Rum"
                        });
                });

            modelBuilder.Entity("CourseLibraryAPI.Models.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            AuthorId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Description = "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers.",
                            Title = "Commandeering a Ship Without Getting Caught"
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                            AuthorId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny.",
                            Title = "Overthrowing Mutiny"
                        },
                        new
                        {
                            Id = new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                            AuthorId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Description = "Every good pirate loves rum, but it also has a tendency to get you into trouble.  In this course you'll learn how to avoid that.  This new exclusive edition includes an additional chapter on how to run fast without falling while drunk.",
                            Title = "Avoiding Brawls While Drinking as Much Rum as You Desire"
                        },
                        new
                        {
                            Id = new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                            AuthorId = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            Description = "In this course you'll learn how to sing all-time favourite pirate songs without sounding like you actually know the words or how to hold a note.",
                            Title = "Singalong Pirate Hits"
                        });
                });

            modelBuilder.Entity("CourseLibraryAPI.Models.Entities.Course", b =>
                {
                    b.HasOne("CourseLibraryAPI.Models.Entities.Author", "Author")
                        .WithMany("Courses")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("CourseLibraryAPI.Models.Entities.Author", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
