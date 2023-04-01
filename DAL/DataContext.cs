using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql(b => b.MigrationsAssembly("ConsoleInterface"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goal>().ToTable(nameof(Goals));
            modelBuilder.Entity<Infraction>().ToTable(nameof(Infractions));
            modelBuilder.Entity<MatchStatistic>().ToTable(nameof(MatchStatistics));
            modelBuilder.Entity<Penalty>().ToTable(nameof(Penalties));
            modelBuilder.Entity<Player>().ToTable(nameof(Players));
            modelBuilder.Entity<Team>().ToTable(nameof(Teams));
            modelBuilder.Entity<TeamStatistic>().ToTable(nameof(TeamStatistics));
        }

        public DbSet<Goal> Goals => Set<Goal>();
        public DbSet<Infraction> Infractions => Set<Infraction>();
        public DbSet<Match> Matches => Set<Match>();
        public DbSet<MatchStatistic> MatchStatistics => Set<MatchStatistic>();
        public DbSet<Penalty> Penalties => Set<Penalty>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<TeamStatistic> TeamStatistics => Set<TeamStatistic>();
    }
}
