using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Miam.DataLayer;
using Miam.Domain.Entities;

namespace Miam.TestUtility.TestsAPI
{
    public class TagTestApi
    {
        private IDbContextFactory<MiamDbContext> _dbContextFactory;

        public TagTestApi(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Create(IEnumerable<Tag> restaurantTags)
        {
            var dbContext = _dbContextFactory.Create();
            foreach (var tag in restaurantTags)
            {
                dbContext.RestaurantTags.Add(tag);
            }
            dbContext.SaveChanges();
        }

        public int Count()
        {
            var dbContext = _dbContextFactory.Create();
            return dbContext.RestaurantTags.Count();
        }
    }
}