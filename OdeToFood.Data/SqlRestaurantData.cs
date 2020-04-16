using System.Collections.Generic;
using System.Linq;
using OdeToFood.core;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public int Commit()
        {
           return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);

            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return db.Restaurants
                .Where(x => x.Name.StartsWith(name) || string.IsNullOrEmpty(name))
                .OrderBy(x => x.Name);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
           var entity =  db.Restaurants.Attach(updatedRestaurant);

           entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

           return updatedRestaurant;
        }
    }
}
