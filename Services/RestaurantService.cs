using Abstructs;
using AutoMapper;
using Dto;
using Formation_web_api.DbContexts;
using Formation_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RestaurantService : IRestaurantService
    {

      
        private readonly RestaurantContext restaurantContext;
        private readonly IMapper mapper;

        public RestaurantService(RestaurantContext restaurantContext,IMapper mapper)
        {
            this.restaurantContext = restaurantContext;
            this.mapper = mapper;
        }
        public RestaurantDto CreateRestaurant(RestaurantDto restaurant)
        {
    

            var restaurantEntity=mapper.Map<Restaurant>(restaurant);
            restaurantContext.Restaurants.Add(restaurantEntity);  

            restaurantContext.SaveChanges();
            restaurant.Id=restaurantEntity.Id;  
            
            return restaurant;


        }

        public RestaurantDto DeleteRestaurant(int id)
        {
            var restaurant =restaurantContext.Restaurants.FirstOrDefault(x => x.Id == id);

            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);


            if (restaurant != null)
            {
                restaurantContext.Restaurants.Remove(restaurant);
            }

           

            return restaurantDto;
        }

        public RestaurantDto GetRestaurant(int id)
        {
           
           var restaurant = restaurantContext.Restaurants.Where(r => r.Id == id).FirstOrDefault();
            //MAp entity-> dto
            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

            return restaurantDto;
        }

        public List<RestaurantDto> GetRestaurants()
        {

            var restaurants = restaurantContext.Restaurants.ToList();

            List<RestaurantDto> restaurantsDto = mapper.Map<List<RestaurantDto>>(restaurants);

            //List <RestaurantDto> restaurantsDto=new List<RestaurantDto> (); 
            //foreach(var restaurant in restaurants)
            //{
            //    restaurantsDto.Add(new RestaurantDto()
            //    {
            //        Id = restaurant.Id,
            //        Name = restaurant.Name,
            //        Description = restaurant.Description,
            //    });
            //}
            return restaurantsDto;
        }

        public void SaveChanges()
        {
           restaurantContext.SaveChanges();
        }

        public RestaurantDto UpdateRestaurant(int id,RestaurantDto newRestaurant)
        {

            //update this function problem reference element
            var restaurant = restaurantContext.Restaurants.Where(r => r.Id == id).FirstOrDefault();

            if (restaurant != null)
            {
                restaurant.Name = newRestaurant.Name;
                restaurant.Description = newRestaurant.Description;
            }

            RestaurantDto restaurantDto = mapper.Map<RestaurantDto>(restaurant);
            
            return restaurantDto;
        }

        
    }
}
