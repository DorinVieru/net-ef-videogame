using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class GamesContext : DbContext
    {
        private string SqlServer = "Data Source=localhost;Initial Catalog=db_games;Integrated Security=True;TrustServerCertificate=True";

        public DbSet<Games> Games { get; set; }
        public DbSet<SoftwareHouse> SoftwareHouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlServer);
        }
    }
}
