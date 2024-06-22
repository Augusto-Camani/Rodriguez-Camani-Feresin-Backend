using Microsoft.EntityFrameworkCore;
using Rodriguez_Camani_Feresin_Backend.Enums;
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend;

public class DbContextCFR : DbContext
{
    public DbContextCFR(DbContextOptions<DbContextCFR> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Barber> Barbers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<BarberAvailability> BarberAvailabilities { get; set; }
    public DbSet<BarberSchedule> BarberSchedules { get ;set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Reply> Replies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasDiscriminator<UserType>("UserType")
            .HasValue<Admin>(UserType.Admin)
            .HasValue<Barber>(UserType.Barber)
            .HasValue<Client>(UserType.Client);

        modelBuilder.Entity<Client>(entity =>
        {
            //entity.ToTable("Clients");
            entity.HasMany(e => e.Appointments);
        });

        modelBuilder.Entity<Barber>(entity =>
        {
            //entity.ToTable("Barbers");
            entity.HasMany(e => e.Appointments);
        }
        );

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointments");
            entity.HasKey(e => e.AppointmentId);
            entity.HasOne(ap => ap.Client)
                .WithMany(cl => cl.Appointments)
                .HasForeignKey(cl => cl.ClientId);
            entity.HasOne(ap => ap.Barber)
                .WithMany(br => br.Appointments)
                .HasForeignKey(br => br.BarberId);
            entity.HasOne(ap => ap.Review)
                .WithOne(re => re.Appointment)
                .HasForeignKey<Review>(re => re.ReviewId);
        });

        modelBuilder.Entity<BarberAvailability>(entity => 
        {
            entity.ToTable("BarberAvailabilities");
            entity.HasKey(e => e.BarberAvailabilityId);
            entity.HasOne(ba => ba.BarberSchedule)
                .WithMany(bs => bs.AvailabilitySlots)
                .HasForeignKey(ba => ba.BarberScheduleId);
        });

        modelBuilder.Entity<BarberSchedule>(entity => 
        {
            entity.ToTable("BarberShcedules");
            entity.HasKey(e => e.BarberScheduleId);
            entity.HasMany(bs => bs.AvailabilitySlots)
                .WithOne(ba => ba.BarberSchedule)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Reviwes");
            entity.HasKey(e => e.ReviewId);
            entity.HasOne(re => re.Reply)
                .WithOne(rp => rp.Review)
                .HasForeignKey<Reply>(rp => rp.ReviewId);
        });


        base.OnModelCreating(modelBuilder);
    }
}
