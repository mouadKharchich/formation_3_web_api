using Formation_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstructs
{
    public interface IRestaurantRepository
    {
        List<Restaurant> Restaurants { get; set; }

        //public void Create(Restaurant restaurant);  

        //public void Update(Restaurant restaurant);  

        //public List<Restaurant> GetAll();

        //public Restaurant GetById(int id);

        //public void Delete(int id);
        void SaveChanges();

    }
}
