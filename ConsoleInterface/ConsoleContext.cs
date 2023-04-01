using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ConsoleInterface
{
    public class ConsoleContext : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            var connectionString = "Server=localhost;Port=5432;Database=hockey_db;User Id=postgres;Password=w1w2w3w4";
            builder.UseNpgsql(connectionString, b => b.MigrationsAssembly("ConsoleInterface"));

            return new DataContext(builder.Options);
        }
    }
}
