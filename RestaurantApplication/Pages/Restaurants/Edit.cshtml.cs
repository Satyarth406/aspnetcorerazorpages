using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantApplication.Models;
using RestaurantApplication.Repository;

namespace RestaurantApplication.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IHtmlHelper _htmlHelper;

        public EditModel(IRestaurantRepository restaurantRepository, IHtmlHelper htmlHelper)
        {
            _restaurantRepository = restaurantRepository;
            _htmlHelper = htmlHelper;
        }

        public List<SelectListItem> Cuisines { get; set; }
        [BindProperty]
        public Models.Restaurant Restaurant { get; set; }

        public void OnGet(int id)
        {
            Restaurant = _restaurantRepository.GetRestaurantById(id);
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>().ToList();
        }

        public IActionResult OnPost()
        {
            _restaurantRepository.UpdateRestaurant(Restaurant);
            return RedirectToPage("allRestaurants");
        }
    }
}