using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions; 

namespace DataAccess.LegendsOfLunchtime
{
    public class Repository : DbContext
    {
        public Repository()
            : base("Repository")
        {
        }

        public DbSet<Models.LegendsOfLunchtime.Brand> Brands { get; set; }
        public DbSet<Models.LegendsOfLunchtime.Product> Products { get; set; }
        public DbSet<Models.LegendsOfLunchtime.ProductType> ProductTypes { get; set; }
        public DbSet<Models.LegendsOfLunchtime.Rating> Ratings { get; set; }
        public DbSet<Models.LegendsOfLunchtime.RatingType> RatingTypes { get; set; }
        public DbSet<Models.LegendsOfLunchtime.Review> Reviews { get; set; }
        public DbSet<Models.LegendsOfLunchtime.User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention then the generated tables will have pluralized names. 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Models.LegendsOfLunchtime.Brand>().ToTable("LoL_Brand");
            modelBuilder.Entity<Models.LegendsOfLunchtime.Product>().ToTable("LoL_Product");
            modelBuilder.Entity<Models.LegendsOfLunchtime.ProductType>().ToTable("LoL_ProductType")
                .HasMany<Models.LegendsOfLunchtime.RatingType>(s => s.RatingTypes)
                   .WithMany(c => c.ProductTypes)
                   .Map(cs =>
                   {
                       cs.MapLeftKey("ProductTypeId");
                       cs.MapRightKey("RatingTypeId");
                       cs.ToTable("LoL_ProductType_RatingType");
                   });
            modelBuilder.Entity<Models.LegendsOfLunchtime.Rating>().ToTable("LoL_Rating");
            modelBuilder.Entity<Models.LegendsOfLunchtime.RatingType>().ToTable("LoL_RatingType");
            modelBuilder.Entity<Models.LegendsOfLunchtime.Review>().ToTable("LoL_Review");
            modelBuilder.Entity<Models.LegendsOfLunchtime.User>().ToTable("LoL_User");

        }
    }
}
