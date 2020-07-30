using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantApplication.Models;
using RestaurantApplication.Repository;

namespace RestaurantApplication.Pages.Restaurants
{
    public class CreateModel : PageModel
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IHtmlHelper _htmlHelper;

        public CreateModel(IRestaurantRepository restaurantRepository, IHtmlHelper htmlHelper)
        {
            _restaurantRepository = restaurantRepository;
            _htmlHelper = htmlHelper;
        }


        public List<SelectListItem> Cuisines{ get; set; }

        [BindProperty]
        public Models.Restaurant Restaurant { get; set; }
        public void OnGet()
        {
            Restaurant = new Models.Restaurant();
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>().ToList();
        }

        public IActionResult OnPost()
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>().ToList();
            _restaurantRepository.CreateRestaurant(Restaurant);
            return RedirectToPage("allRestaurants");

        }
    }

}