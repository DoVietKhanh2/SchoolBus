using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolB.Models
{
    public partial class SchoolBusContext : DbContext
    {
        public SchoolBusContext()
        {
        }

        public SchoolBusContext(DbContextOptions<SchoolBusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<Route> Routes { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<bus> Buses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-H1AJ1A1;database=SchoolBus;uid=sa;pwd=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.Property(e => e.EndLocation).HasMaxLength(255);

                entity.Property(e => e.RouteName).HasMaxLength(100);

                entity.Property(e => e.StartLocation).HasMaxLength(255);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.BusId).HasColumnName("BusID");

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.BusId)
                    .HasConstraintName("FK__Tickets__BusID__4D94879B");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.RouteId)
                    .HasConstraintName("FK__Tickets__RouteID__4CA06362");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Tickets__UserID__4BAC3F29");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<bus>(entity =>
            {
                entity.Property(e => e.BusId).HasColumnName("BusID");

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.buses)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__Buses__DriverID__3D5E1FD2");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.buses)
                    .HasForeignKey(d => d.RouteId)
                    .HasConstraintName("FK__Buses__RouteID__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
