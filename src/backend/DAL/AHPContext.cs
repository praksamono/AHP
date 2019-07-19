using Microsoft.EntityFrameworkCore;
using System;


namespace DAL
{
    public class AHPContext : DbContext
    {
        public AHPContext(DbContextOptions<AHPContext> options)
            : base(options)
        {
        }

        public DbSet<Goal> Goals{get; set;}

        public DbSet<Criterium> Criteriums { get; set; }

        public DbSet<Criterium_Alternative> Criterium_Alternatives { get; set; }

        public DbSet<Alternative> Alternatives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Criterium_Alternative>()
                .HasKey(ca => new { ca.CriteriumId, ca.AlternativeId });

            modelBuilder.Entity<Criterium_Alternative>()
                .HasOne(ca => ca.criterium)
                .WithMany(c => c.criterium_alternatives)
                .HasForeignKey(ca => ca.CriteriumId);

            modelBuilder.Entity<Criterium_Alternative>()
                .HasOne(ca => ca.alternative)
                .WithMany(a => a.criterium_alternatives)
                .HasForeignKey(ca => ca.AlternativeId);
        }

    }
}
