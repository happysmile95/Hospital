using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Site>(p =>
            {
                p.HasIndex(e => e.Id);
                p.Property(e => e.Number).IsRequired();
            });

            modelBuilder.Entity<Specialization>(p =>
            {
                p.HasIndex(e => e.Id);
                p.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Parlor>(p =>
            {
                p.HasIndex(e => e.Id);
                p.Property(e => e.Number).IsRequired();
            });

            modelBuilder.Entity<Patient>(p =>
            {
                p.HasIndex(e => e.Id);
                p.Property(e => e.FirstName).HasMaxLength(250).IsRequired();
                p.Property(e => e.LastName).HasMaxLength(250).IsRequired();
                p.Property(e => e.Patronymic).HasMaxLength(250).IsRequired();
                p.Property(e => e.Address).HasMaxLength(500).IsRequired();
                p.Property(e => e.BirthDay).IsRequired();

                p.HasOne(e => e.Site).WithMany(e => e.Patients).HasForeignKey(e => e.SiteId);
            });

            modelBuilder.Entity<Doctor>(p =>
            {
                p.HasIndex(e => e.Id);
                p.Property(e => e.Name).HasMaxLength(250).IsRequired();

                p.HasOne(e => e.Parlor).WithMany(e => e.Doctors).HasForeignKey(e => e.ParlorId);
                p.HasOne(e => e.Site).WithMany(e => e.Doctors).HasForeignKey(e => e.SiteId);
                p.HasOne(e => e.Specialization).WithMany(e => e.Doctors).HasForeignKey(e => e.SpecializationId);
            });
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Parlor> Parlors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
    }
}
