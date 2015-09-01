using System.Data.Entity.Infrastructure;
using System.Linq;
using Miam.DataLayer;
using Miam.Domain.Entities;

namespace Miam.TestUtility.DbTestsHelperAPI
{
    public class TagTestHelper
    {
        private readonly IDbContextFactory<MiamDbContext> _dbContextFactory;

        public TagTestHelper(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public int Count()
        {
            var dbContext = _dbContextFactory.Create();
            return dbContext.RestaurantTags.Count();
        }
    }
}