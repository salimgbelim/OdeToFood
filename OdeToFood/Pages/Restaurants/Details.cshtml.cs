using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public Restaurant Restaurant { get; set; }

        public readonly IRestaurantData RestaurantData;

        public DetailsModel(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            this.Restaurant = RestaurantData.GetById(restaurantId);

            if(this.Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
