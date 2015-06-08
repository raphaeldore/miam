using System.Linq;
using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;

namespace Miam.AcceptanceTests.Automation.AcceptanceTestApi
{
    public class RestaurantAcceptanceTestApi
    {
        private IEntityRepository<Restaurant> _restaurantRepository;

        public RestaurantAcceptanceTestApi()
        {
            _restaurantRepository = new EfEntityRepository<Restaurant>();
        }
        public void CreateRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.Add(restaurant);
        }

        public Restaurant GetFirstRestaurant()
        {
            _restaurantRepository = new EfEntityRepository<Restaurant>(); // nécessaire pour avoir le dernier "context".
            return _restaurantRepository.GetAll().First();
        }
    }
}
