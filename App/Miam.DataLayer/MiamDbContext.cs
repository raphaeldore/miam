using System.Data.Entity;
using Miam.Domain.Entities;

namespace Miam.DataLayer
{
    public class MiamDbContext : DbContext
    {
    
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantContactDetail> RestaurantContactDetails { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Tag> RestaurantTags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantContactDetail>().HasKey(c => c.RestaurantId);
            
            modelBuilder.Entity<RestaurantContactDetail>()
                .HasRequired(c => c.Restaurant)
                .WithOptional(r => r.RestaurantContactDetail)
                .WillCascadeOnDelete();

            base.OnModelCreating(modelBuilder);
        }

    }
}