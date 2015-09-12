using System.Data.Entity.Infrastructure;
using System.Linq;
using Miam.DataLayer;
using Miam.Domain.Entities;

namespace Miam.TestUtility.TestsHelperAPI
{
    public class RestaurantTestHelper : BaseTestHelper
    {
        private readonly IDbContextFactory<MiamDbContext> _dbContextFactory;

        public RestaurantTestHelper(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Add(Restaurant restaurant)
        {
            var dbContext = _dbContextFactory.Create();
            dbContext.Restaurants.Add(restaurant);
            dbContext.SaveChanges();
        }

        public int Count()
        {
            var dbContext = _dbContextFactory.Create();
            return dbContext.Restaurants.Count();
        }

        public Restaurant GetFirst()
        {
            var dbContext = _dbContextFactory.Create();
            return dbContext.Restaurants.First();
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

        public RestaurantContactDetail GetContactDetailOf(Restaurant restaurant)
        {
            var dbContext = _dbContextFactory.Create();
            var resto = dbContext.Restaurants.FirstOrDefault(x => x.Id == restaurant.Id);
            return resto.RestaurantContactDetail;
        }
    }
}
