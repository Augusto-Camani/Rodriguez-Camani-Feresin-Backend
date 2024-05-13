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
    public DbSet<Review> Reviws { get; set; }
    public DbSet<Reply> Replies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasDiscriminator<UserType>("UserType")
            .HasValue<Admin>(UserType.Admin)
            .HasValue<Barber>(UserType.Barber)
            .HasValue<Client>(UserType.Client);

        modelBuilder.Entity<Client>(entity =>
        {
        });

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
        });



        base.OnModelCreating(modelBuilder);
    }
}
