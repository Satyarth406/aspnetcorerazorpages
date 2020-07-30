using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantApplication.Repository;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantApplication.Pages.Restaurants
{
    public class AllRestaurantsModel : PageModel
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IHtmlHelper _htmlHelper;

        public AllRestaurantsModel(IRestaurantRepository restaurantRepository, IHtmlHelper htmlHelper)
        {
            _restaurantRepository = restaurantRepository;
            _htmlHelper = htmlHelper;
        }

        public List<Models.Restaurant> Restaurants { get; set; }
        public void OnGet()
        {
            Restaurants = _restaurantRepository.AllRestaurants();
        }

        public IActionResult OnPostDelete(int id)
        {
            _restaurantRepository.DeleteRestaurant(id);
            Restaurants = _restaurantRepository.AllRestaurants();

            return Page();
        }
    }
}