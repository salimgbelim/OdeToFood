using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id=1, Name ="Scott's Pizza", Location= "Maryland", Cusine= CusineType.Italian},
                new Restaurant {Id=2, Name ="Cinnamon Club", Location= "London", Cusine= CusineType.Indian},
                new Restaurant {Id=3, Name ="La Costa", Location= "Caifornia", Cusine= CusineType.Mexican}
            };

        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                return restaurants.OrderBy(x => x.Name);
            }

            return restaurants
                .Where(x => x.Name.StartsWith(name))
                .OrderBy(x => x.Name);

        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(x => x.Id) + 1;
            restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(x => x.Id == updatedRestaurant.Id);

            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cusine = updatedRestaurant.Cusine;
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(x => x.Id == id);

            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }
    }
}
