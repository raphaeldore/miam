using System.Data.Entity.Infrastructure;
using System.Linq;
using Miam.DataLayer;
using Miam.Domain.Entities;

namespace Miam.TestUtility.DbTestsHelperAPI
{
    public class WriterTestHelper : BaseTestHelper
    {
        private readonly IDbContextFactory<MiamDbContext> _dbContextFactory;

        public WriterTestHelper(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Add(Writer writer)
        {
            var dbContext = _dbContextFactory.Create();
            dbContext.Writers.Add(writer);
            dbContext.SaveChanges();
        }

        public int GetReviewsCountFor(Restaurant restaurant)
        {
            var dbContext = _dbContextFactory.Create();
            var resto = dbContext.Restaurants.FirstOrDefault(x => x.Id == restaurant.Id);
            return resto.Reviews.Count();
        }
    }
}