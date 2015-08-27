using System.Linq;
using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;
using Miam.TestUtility.AutoFixture;
using Ploeh.AutoFixture;

namespace Miam.TestUtility.TestsAPI
{
    public class RestaurantTestHelperApi : BaseTestHelper
    {
        private IEntityRepository<Restaurant> _restaurantRepository;
        

        public RestaurantTestHelperApi(ApplicationContext applicationContext)
        {
            _restaurantRepository = new EfEntityRepository<Restaurant>(new ApplicationContext());
        }
        public void CreateRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.Add(restaurant);
        }

        public Restaurant GetFirstRestaurant()
        {
            _restaurantRepository = new EfEntityRepository<Restaurant>(new ApplicationContext()); // nécessaire pour avoir le dernier "context".
            return _restaurantRepository.GetAll().First();
        }

        public int GetRestaurantCount()
        {
            using (var miamDbContext = new MiamDbContext())
            {
                return miamDbContext.Restaurants.Count();
            }
        }

        public Restaurant Create()
        {
            var restaurant = Fixture.Create<Restaurant>();
            using (var miamDbContext = new MiamDbContext())
            {
                miamDbContext.Restaurants.Attach(restaurant);
                miamDbContext.Restaurants.Add(restaurant);
                miamDbContext.SaveChanges();

                return restaurant;
            }
        }

        public Restaurant GetRestaurant(Restaurant restaurant)
        {
            using (var miamDbContext = new MiamDbContext())
            {
                return miamDbContext.Restaurants.FirstOrDefault(x => x.Id == restaurant.Id);
            }
        }
    }
}
