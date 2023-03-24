using AutoMapper;
using Dto;
using Formation_web_api.Models;
using Formation_web_api.Requestes;
using Formation_web_api.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilMappers
{
    public class RestaurantProfil:Profile
    {
        public RestaurantProfil()
        {
            CreateMap<Restaurant,RestaurantDto>();
            CreateMap<RestaurantRequest, RestaurantDto>();
            CreateMap<RestaurantDto, Restaurant>();
            CreateMap<RestaurantDto, RestaurantResponse>();
        }
    }
}
