using System.Data.Entity.Infrastructure;
using System.Linq;
using Miam.DataLayer;
using Miam.Domain.Entities;

namespace Miam.TestUtility.TestsAPI
{
    public class RestaurantContactDetailTestHelper
    {
        private IDbContextFactory<MiamDbContext> _dbContextFactory;

        public RestaurantContactDetailTestHelper(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Create(RestaurantContactDetail restaurantContactDetail)
        {
            var dbContext = _dbContextFactory.Create();
            dbContext.RestaurantContactDetails.Add(restaurantContactDetail);
            dbContext.SaveChanges();
        }

        public int Count()
        {
            var dbContext = _dbContextFactory.Create();
            return dbContext.RestaurantContactDetails.Count();
        }
    }
}