
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Henris Indiska", Location="Stockholm",Cousine=CuisineType.Indian },
                new Restaurant { Id = 2, Name = "Henris Pizza", Location="Stockholm",Cousine=CuisineType.Italian },
                new Restaurant { Id = 3, Name = "Henris Taco", Location="Stockholm",Cousine=CuisineType.Mexican },
                new Restaurant { Id = 4, Name = "Henris Bar", Location="Stockholm",Cousine=CuisineType.None }
            };

        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cousine = updatedRestaurant.Cousine;
            }
            return restaurant;
        }

       public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id + 1);
            return newRestaurant;
        }


        public IEnumerable<Restaurant> GetResturantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }
    }

}
