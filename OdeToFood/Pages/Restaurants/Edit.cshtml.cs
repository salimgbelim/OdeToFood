using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cusines { get; set; }

        public EditModel(IRestaurantData restaurantData,
                         IHtmlHelper htmlHelper)
        {
            this.restaurantData =  restaurantData;
            this.htmlHelper = htmlHelper;
        }

       
        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue)
            {
                this.Restaurant = this.restaurantData.GetById(restaurantId.Value);
            }
            else
            {
                this.Restaurant = new Restaurant();
            }

            if (this.Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            this.Cusines = htmlHelper.GetEnumSelectList<CusineType>();


            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                this.Cusines = htmlHelper.GetEnumSelectList<CusineType>();

                return Page();
            }

            if(Restaurant.Id > 0)
            {
                TempData["Message"] = "Restaurant updated!";

                Restaurant = restaurantData.Update(Restaurant);
            }
            else
            {
                TempData["Message"] = "New Restaurant saved!";

                Restaurant = restaurantData.Add(Restaurant);
            }
          
            restaurantData.Commit();
        
            return RedirectToPage("./Details",
                new { restaurantId = Restaurant.Id}
            );
          
        }
    }
}
