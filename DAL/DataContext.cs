using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
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
