using System;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        public readonly IRestaurantData RestaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.RestaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            int countOfRestaurants = this.RestaurantData.GetCountOfRestaurants();

            return View("Count", countOfRestaurants);
        }
       
    }
}
