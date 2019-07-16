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

        public DbSet<Goal>Goals{get; set;}

        public DbSet<Criterium> Criteriums { get; set; }

        public DbSet<Criterium_Alternative> Criterium_Alternatives { get; set; }

        public DbSet<Alternative> Alternatives { get; set; }

    }
}
