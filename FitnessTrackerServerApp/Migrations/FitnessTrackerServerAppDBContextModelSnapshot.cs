﻿// <auto-generated />
using System;
using FitnessTrackerServerApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessTrackerServerApp.Migrations
{
    [DbContext(typeof(FitnessTrackerServerAppDBContext))]
    partial class FitnessTrackerServerAppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.20");

            modelBuilder.Entity("FitnessTrackerApp.Model.CheatMealEntry", b =>
                {
                    b.Property<Guid?>("CheatMealEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Calories")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("MealName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WeightEntryId")
                        .HasColumnType("TEXT");

                    b.HasKey("CheatMealEntryId");

                    b.HasIndex("WeightEntryId");

                    b.ToTable("CheatMealEntry");
                });

            modelBuilder.Entity("FitnessTrackerApp.Model.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateofBirth")
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Height")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserName");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserName = "jamith",
                            DateofBirth = new DateTime(1998, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = 0,
                            Height = 183m,
                            Name = "Jamith Nimantha",
                            Password = "pCVA+jmMayKhtXV2/gUGP1wnYX3R5JNvy52q1Vy8Yj4="
                        },
                        new
                        {
                            UserName = "admin",
                            DateofBirth = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = 0,
                            Height = 183m,
                            Name = "Admin",
                            Password = "pCVA+jmMayKhtXV2/gUGP1wnYX3R5JNvy52q1Vy8Yj4="
                        });
                });

            modelBuilder.Entity("FitnessTrackerApp.Model.WeightEntry", b =>
                {
                    b.Property<Guid?>("WeightEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("WeightEntryId");

                    b.ToTable("WeightEntry");

                    b.HasData(
                        new
                        {
                            WeightEntryId = new Guid("0a5099b5-d7be-4948-871e-897c487a5f4c"),
                            Date = new DateTime(2021, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "jamith",
                            Weight = 80m
                        });
                });

            modelBuilder.Entity("FitnessTrackerApp.Model.WorkoutEntry", b =>
                {
                    b.Property<Guid?>("WorkoutEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CaloriesBurned")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Intensity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WeightEntryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkoutName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WorkoutEntryId");

                    b.HasIndex("WeightEntryId");

                    b.ToTable("WorkoutEntry");
                });

            modelBuilder.Entity("FitnessTrackerApp.Model.CheatMealEntry", b =>
                {
                    b.HasOne("FitnessTrackerApp.Model.WeightEntry", "WeightEntry")
                        .WithMany()
                        .HasForeignKey("WeightEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WeightEntry");
                });

            modelBuilder.Entity("FitnessTrackerApp.Model.WorkoutEntry", b =>
                {
                    b.HasOne("FitnessTrackerApp.Model.WeightEntry", "WeightEntry")
                        .WithMany()
                        .HasForeignKey("WeightEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WeightEntry");
                });
#pragma warning restore 612, 618
        }
    }
}
