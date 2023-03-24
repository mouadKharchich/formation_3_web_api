using Abstructs;
using Formation_web_api.DbContexts;
using Formation_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RestaurantRepository:IRestaurantRepository
    {
        private readonly RestaurantContext restaurantContext;

        public RestaurantRepository(RestaurantContext restaurantContext)
        {
            this.restaurantContext = restaurantContext;
        }
        public List<Restaurant> Restaurants { get; set; }

        public RestaurantRepository()
        {
            //Restaurants = restaurantContext.Restaurants.ToList();   
        }

        public void SaveChanges()
        {
           // restaurantContext.SaveChanges();
        }
    }
}
