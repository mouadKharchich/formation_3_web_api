using Formation_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Formation_web_api.DbContexts
{
    public class RestaurantContext:DbContext
    {

        public RestaurantContext(DbContextOptions<RestaurantContext>options):base(options)
        {}

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
