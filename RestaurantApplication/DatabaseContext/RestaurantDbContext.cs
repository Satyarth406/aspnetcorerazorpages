using Microsoft.EntityFrameworkCore;
using RestaurantApplication.Models;

namespace RestaurantApplication.DatabaseContext
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasData(
                new { Id = 1, Name = "Restaurant 1", City = "Bangalore", Cuisine = CuisineType.Indian },
                new { Id = 2, Name = "Restaurant 2", City= "Mumbai", Cuisine = CuisineType.None },
                new { Id = 3, Name = "Restaurant 3", City= "Delhi", Cuisine = CuisineType.Chinese },
                new { Id = 4, Name = "Restaurant 4", City = "Kolkata", Cuisine = CuisineType.Mexican }
                );


        }
    }
}
