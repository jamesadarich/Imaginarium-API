using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LegendsOfLunchtime.DataAccess
{
    public class Repository : DbContext
    {
        public Repository()
            : base("Repository")
        {
            Database.SetInitializer<Repository>(null);
        }

        public DbSet<Models.Brand> Brands { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.ProductType> ProductTypes { get; set; }
        public DbSet<Models.Rating> Ratings { get; set; }
        public DbSet<Models.RatingType> RatingTypes { get; set; }
        public DbSet<Models.Review> Reviews { get; set; }
        public DbSet<Models.User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention then the generated tables will have pluralized names. 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Models.Brand>().ToTable("LoL_Brand");
            modelBuilder.Entity<Models.Product>().ToTable("LoL_Product");
            modelBuilder.Entity<Models.ProductType>().ToTable("LoL_ProductType")
                .HasMany<Models.RatingType>(s => s.RatingTypes)
                   .WithMany(c => c.ProductTypes)
                   .Map(cs =>
                   {
                       cs.MapLeftKey("ProductTypeId");
                       cs.MapRightKey("RatingTypeId");
                       cs.ToTable("LoL_ProductType_RatingType");
                   });
            modelBuilder.Entity<Models.Rating>().ToTable("LoL_Rating");
            modelBuilder.Entity<Models.RatingType>().ToTable("LoL_RatingType");
            modelBuilder.Entity<Models.Review>().ToTable("LoL_Review");
            modelBuilder.Entity<Models.User>().ToTable("LoL_User");

        }
    }
}
