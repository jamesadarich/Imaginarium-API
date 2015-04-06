using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions; 

namespace TeamBuilder.DataAccess
{
    public class Repository : DbContext
    {
        public Repository()
            : base("Repository")
        {
        }

        public DbSet<Models.Match> Matches { get; set; }
        public DbSet<Models.Player> Players { get; set; }
        public DbSet<Models.Squad> Squads { get; set; }
        public DbSet<Models.Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention then the generated tables will have pluralized names. 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Models.Match>().ToTable("Team_Match");
            modelBuilder.Entity<Models.Player>().ToTable("Team_Player");
            modelBuilder.Entity<Models.Squad>().ToTable("Team_Squad");
            modelBuilder.Entity<Models.Team>().ToTable("Team_Team");
        }
    }
}
