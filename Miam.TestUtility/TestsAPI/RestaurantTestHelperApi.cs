using System.Data.Entity.Infrastructure;
using System.Diagnostics;
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
        private readonly IDbContextFactory<MiamDbContext> _dbContextFactory;

        public RestaurantTestHelperApi(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public void Create(Restaurant restaurant)
        {
            var dbContext = _dbContextFactory.Create();
            dbContext.Restaurants.Attach(restaurant);
            dbContext.Restaurants.Add(restaurant);
            dbContext.SaveChanges();
        }

        public Restaurant GetFirst()
        {
            var dbContext = _dbContextFactory.Create();
            return dbContext.Restaurants.First();
        }

        public int Count()
        {
            var dbContext = _dbContextFactory.Create();
            return dbContext.Restaurants.Count();
        }

        public Restaurant GetRestaurant(Restaurant restaurant)
        {
            var dbContext = _dbContextFactory.Create();
            var resto = dbContext.Restaurants.FirstOrDefault(x => x.Id == restaurant.Id);
            return resto;
        }

        public Review GetFirstReviewOf(Restaurant restaurant)
        {
            var dbContext = _dbContextFactory.Create();
            return dbContext.Restaurants
                            .First(x => x.Id == restaurant.Id)
                            .Reviews.First();
        }

        //public int CountReviewsOf(Restaurant restaurant)
        //{
        //    var dbContext = _dbContextFactory.Create();
        //    var resto = dbContext.Restaurants.FirstOrDefault(x => x.Id == restaurant.Id);
        //    return resto.Reviews.Count();
        //}

        public RestaurantContactDetail GetContactDetailOf(Restaurant restaurant)
        {
            var dbContext = _dbContextFactory.Create();
            var resto = dbContext.Restaurants.FirstOrDefault(x => x.Id == restaurant.Id);
            return resto.RestaurantContactDetail;
        }
    }
}
