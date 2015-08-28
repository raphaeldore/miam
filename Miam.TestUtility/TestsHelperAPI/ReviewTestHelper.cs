using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.TestUtility.AutoFixture;
using Ploeh.AutoFixture;

namespace Miam.TestUtility.TestsAPI
{
    public class ReviewTestHelper : BaseTestHelper
    {
        private readonly IDbContextFactory<MiamDbContext> _dbContextFactory;

        public ReviewTestHelper(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Create(Review review)
        {
            var dbContext = _dbContextFactory.Create();
            dbContext.Reviews.Add(review);
            dbContext.SaveChanges();
        }

        public int Count()
        {
            var dbContext = _dbContextFactory.Create();
            return dbContext.Reviews.Count();
        }
    }
}