using System.Data.Entity.Infrastructure;
using System.Linq;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Ploeh.AutoFixture;

namespace Miam.TestUtility.TestsAPI
{
    public class WriterTestHelper : BaseTestHelper
    {
        private IDbContextFactory<MiamDbContext> _dbContextFactory;


        public WriterTestHelper(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

        }

        public void Create(Writer writer)
        {
            var dbContext = _dbContextFactory.Create();
            dbContext.Writers.Attach(writer);
            dbContext.Writers.Add(writer);
            dbContext.SaveChanges();
        }

        public int GetReviewsCount(Restaurant restaurant)
        {
            var dbContext = _dbContextFactory.Create();
            var resto = dbContext.Restaurants.FirstOrDefault(x => x.Id == restaurant.Id);
            return resto.Reviews.Count();
        }
    }
}