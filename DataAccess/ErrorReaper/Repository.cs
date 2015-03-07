using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions; 

namespace ErrorReaper.DataAccess
{
    public class Repository : DbContext
    {
        public Repository()
            : base("Repository")
        {
        }

        public DbSet<Models.AndroidReport> AndroidReports { get; set; }
        public DbSet<Models.Application> Applications { get; set; }
        public DbSet<Models.DotNetException> DotNetExceptions { get; set; }
        public DbSet<Models.DotNetReport> DotNetReports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention then the generated tables will have pluralized names. 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Models.AndroidReport>().ToTable("Err_Brand");
            modelBuilder.Entity<Models.Application>().ToTable("Err_Application");
            modelBuilder.Entity<Models.DotNetException>().ToTable("Err_DotNetException");
            modelBuilder.Entity<Models.DotNetReport>().ToTable("Err_DotNetReport");
        }
    }
}
