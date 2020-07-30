using RestaurantApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApplication.Repository
{
    public interface IRestaurantRepository
    {
        List<Restaurant> AllRestaurants();
        Restaurant GetRestaurantById(int id);
        Restaurant UpdateRestaurant(Restaurant updatedRestaurant);
        Restaurant CreateRestaurant(Restaurant newRestaurant);
        void DeleteRestaurant(int id);
    }
}
