using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhilosophersLibrary.Models.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PhilosophersLibrary.DAL
{
    public class PhilosopherContext : DbContext
    {

        public DbSet<Philosopher> Philosopher { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<Book> Book { get; set; }

        public PhilosopherContext() : base("PhilosopherContext")
        {
            Database.SetInitializer(new PhilosopherInitialiser());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasRequired(p => p.Philosopher)
                .WithMany()
                .HasForeignKey(p => p.PhilosopherID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Philosopher>()
                .Property(p => p.DateOfBirth)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Philosopher>()
                .Property(p => p.DateOfDeath)
                .HasColumnType("datetime2");
        }
    }
}