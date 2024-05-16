﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rodriguez_Camani_Feresin_Backend;

#nullable disable

namespace Rodriguez_Camani_Feresin_Backend.Migrations
{
    [DbContext(typeof(DbContextCFR))]
    [Migration("20240516202524_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<int>("BarberId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ReceiptNumber")
                        .HasColumnType("int");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("AppointmentId");

                    b.HasIndex("BarberId");

                    b.HasIndex("ClientId");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("UserType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Reply", b =>
                {
                    b.Property<int>("ReplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ReplyId"));

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("ReplyId");

                    b.HasIndex("ReviewId")
                        .IsUnique();

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("ReviewId");

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
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Client", b =>
                {
                    b.HasBaseType("Rodriguez_Camani_Feresin_Backend.Models.User");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Appointment", b =>
                {
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

                    b.Navigation("Client");
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

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Rodriguez_Camani_Feresin_Backend.Appointment", b =>
                {
                    b.Navigation("Review")
                        .IsRequired();
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
