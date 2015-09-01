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

        public void Add(Tag tag)
        {
            var dbContext = _dbContextFactory.Create();
            dbContext.RestaurantTags.Add(tag);
            dbContext.SaveChanges();
        }

        public int Count()
        {
            var dbContext = _dbContextFactory.Create();
            return dbContext.RestaurantTags.Count();
        }

        public Tag GetFirst()
        {
            var dbContext = _dbContextFactory.Create();
            return dbContext.RestaurantTags.First();
        }
    }
}