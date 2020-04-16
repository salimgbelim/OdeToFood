using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        public readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData RestaurantData)
        {
            this.restaurantData = RestaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            this.Restaurant = restaurantData.GetById(restaurantId);

            if(this.Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }


        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = restaurantData.Delete(restaurantId);
            restaurantData.Commit();

            if(restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{restaurant.Name} deleted";

            return RedirectToPage("./List");
        }
    }
}
