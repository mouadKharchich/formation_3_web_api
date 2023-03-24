using Dto;
using Formation_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstructs
{
    public interface IRestaurantService
    {
        List<RestaurantDto> GetRestaurants();

        RestaurantDto GetRestaurant(int id);

        RestaurantDto CreateRestaurant(RestaurantDto restaurant);

        RestaurantDto UpdateRestaurant(int id,RestaurantDto newRestaurant);

        RestaurantDto DeleteRestaurant(int id);

        void SaveChanges();
    }
}
