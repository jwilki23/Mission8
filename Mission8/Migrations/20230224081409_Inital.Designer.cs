﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission8.Models;

namespace Mission8.Migrations
{
    [DbContext(typeof(AddTaskContext))]
    [Migration("20230224081409_Inital")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("Mission8.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Home"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "School"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Work"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Church"
                        });
                });

            modelBuilder.Entity("Mission8.Models.TaskResponse", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quadrant")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            TaskId = 1,
                            CategoryId = 2,
                            Completed = false,
                            DueDate = new DateTime(2023, 2, 24, 11, 59, 59, 0, DateTimeKind.Unspecified),
                            Quadrant = 1,
                            Task = "Mission #8 Project"
                        },
                        new
                        {
                            TaskId = 2,
                            CategoryId = 4,
                            Completed = false,
                            DueDate = new DateTime(2023, 2, 26, 11, 30, 0, 0, DateTimeKind.Unspecified),
                            Quadrant = 2,
                            Task = "Write a talk"
                        },
                        new
                        {
                            TaskId = 3,
                            CategoryId = 1,
                            Completed = false,
                            DueDate = new DateTime(2023, 2, 27, 6, 0, 0, 0, DateTimeKind.Unspecified),
                            Quadrant = 4,
                            Task = "Do my laundry"
                        });
                });

            modelBuilder.Entity("Mission8.Models.TaskResponse", b =>
                {
                    b.HasOne("Mission8.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
