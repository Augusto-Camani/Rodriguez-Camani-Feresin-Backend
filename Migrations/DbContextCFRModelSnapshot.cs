﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rodriguez_Camani_Feresin_Backend;

#nullable disable

namespace Rodriguez_Camani_Feresin_Backend.Migrations
{
    [DbContext(typeof(DbContextCFR))]
    partial class DbContextCFRModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BarberAvailabilityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BarberId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Service")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("AppointmentId");

                    b.HasIndex("BarberAvailabilityId");

                    b.HasIndex("BarberId");

                    b.HasIndex("ClientId");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.BarberAvailability", b =>
                {
                    b.Property<int>("BarberAvailabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AvailabilityDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("BarberScheduleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayOfTheWeek")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("BarberAvailabilityId");

                    b.HasIndex("BarberScheduleId");

                    b.ToTable("BarberAvailabilities", (string)null);
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.BarberSchedule", b =>
                {
                    b.Property<int>("BarberScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BarberId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentYear")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("BarberScheduleId");

                    b.HasIndex("BarberId");

                    b.ToTable("BarberShcedules", (string)null);
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("UserType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Reply", b =>
                {
                    b.Property<int>("ReplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ReviewId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReplyId");

                    b.HasIndex("ReviewId")
                        .IsUnique();

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Rating")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviwes", (string)null);
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Admin", b =>
                {
                    b.HasBaseType("Rodriguez_Camani_Feresin_Backend.Models.User");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Barber", b =>
                {
                    b.HasBaseType("Rodriguez_Camani_Feresin_Backend.Models.User");

                    b.Property<int>("Specialties")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Client", b =>
                {
                    b.HasBaseType("Rodriguez_Camani_Feresin_Backend.Models.User");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Appointment", b =>
                {
                    b.HasOne("Rodriguez_Camani_Feresin_Backend.BarberAvailability", "BarberAvailability")
                        .WithMany()
                        .HasForeignKey("BarberAvailabilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rodriguez_Camani_Feresin_Backend.Barber", "Barber")
                        .WithMany("Appointments")
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rodriguez_Camani_Feresin_Backend.Client", "Client")
                        .WithMany("Appointments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barber");

                    b.Navigation("BarberAvailability");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.BarberAvailability", b =>
                {
                    b.HasOne("Rodriguez_Camani_Feresin_Backend.BarberSchedule", "BarberSchedule")
                        .WithMany("AvailabilitySlots")
                        .HasForeignKey("BarberScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BarberSchedule");
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.BarberSchedule", b =>
                {
                    b.HasOne("Rodriguez_Camani_Feresin_Backend.Barber", "Barber")
                        .WithMany()
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barber");
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Reply", b =>
                {
                    b.HasOne("Rodriguez_Camani_Feresin_Backend.Review", "Review")
                        .WithOne("Reply")
                        .HasForeignKey("Rodriguez_Camani_Feresin_Backend.Reply", "ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Review", b =>
                {
                    b.HasOne("Rodriguez_Camani_Feresin_Backend.Appointment", "Appointment")
                        .WithOne("Review")
                        .HasForeignKey("Rodriguez_Camani_Feresin_Backend.Review", "ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rodriguez_Camani_Feresin_Backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Appointment", b =>
                {
                    b.Navigation("Review")
                        .IsRequired();
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.BarberSchedule", b =>
                {
                    b.Navigation("AvailabilitySlots");
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Review", b =>
                {
                    b.Navigation("Reply")
                        .IsRequired();
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Barber", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Client", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
