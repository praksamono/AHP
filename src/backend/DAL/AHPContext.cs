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

        public DbSet<GoalEntity> Goals{get; set;}

        public DbSet<CriteriumEntity> Criteriums { get; set; }

        public DbSet<CriteriumAlternativeEntity> CriteriumAlternatives { get; set; }

        public DbSet<AlternativeEntity> Alternatives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CriteriumAlternativeEntity>()
                .HasKey(ca => new { ca.CriteriumId, ca.AlternativeId });

            modelBuilder.Entity<CriteriumAlternativeEntity>()
                .HasOne(ca => ca.Criterium)
                .WithMany(c => c.CriteriumAlternatives)
                .HasForeignKey(ca => ca.CriteriumId);

            modelBuilder.Entity<CriteriumAlternativeEntity>()
                .HasOne(ca => ca.Alternative)
                .WithMany(a => a.CriteriumAlternatives)
                .HasForeignKey(ca => ca.AlternativeId);
        }

    }
}
