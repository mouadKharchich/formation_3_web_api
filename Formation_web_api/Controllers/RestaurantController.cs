using Abstructs;
using Dto;
using Formation_web_api.Requestes;
using Formation_web_api.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Formation_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        /// <summary>
        /// Create First Action get all restaurants data
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult GetRestaurants()
        {
            
            //return CreatedAtAction(nameof(GetAll),new object());
            var restaurants = restaurantService.GetRestaurants();
            List<RestaurantResponse> restaurantsResponse=new List<RestaurantResponse>();
            foreach(var restaurant in restaurants)
            {
                restaurantsResponse.Add(new RestaurantResponse
                {
                    Id=restaurant.Id,   
                    Name=restaurant.Name,
                    Description=restaurant.Description,
                });
            }
            return Ok(restaurantsResponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetRestaurant(int id) {
            var restaurant = restaurantService.GetRestaurant(id);
            if(restaurant == null)
            {
                return NotFound();
            }

            var restaurantResponse=MapDtoToResponse(restaurant);

            return Ok(restaurantResponse);
        }

        [HttpPost]
        public IActionResult CreateRestaurant(RestaurantRequest restaurantRequest)
        {
            var restaurantDto=MapRequestToDto(restaurantRequest);

            var restaurant = restaurantService.CreateRestaurant(restaurantDto);
           // restaurantService.SaveChanges();
            var restaurantResponse = MapDtoToResponse(restaurant);
            return Ok(restaurantResponse);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            var restaurant = restaurantService.DeleteRestaurant(id);
           // restaurantService.SaveChanges();

            var restaurantResponse = MapDtoToResponse(restaurant);

            return Ok(restaurantResponse);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant(int id, RestaurantDto updatedRestaurant)
        {
            var restaurant = restaurantService.UpdateRestaurant(id,updatedRestaurant);
           // restaurantService.SaveChanges();

            var restaurantResponse = MapDtoToResponse(restaurant);

            return Ok(restaurantResponse);
        }

        private RestaurantResponse MapDtoToResponse(RestaurantDto dto)
        {
            return new RestaurantResponse()
            {
                Id=dto.Id,
                Name=dto.Name,
                Description=dto.Description,
            };
        }

        private RestaurantDto MapRequestToDto(RestaurantRequest restaurantRequest)
        {
            return new RestaurantDto()
            {
                Id=0,
                Name = restaurantRequest.Name,
                Description = restaurantRequest.Description,
            };
        }

    }
}
