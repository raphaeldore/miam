using System.Data.Entity.Infrastructure;
using Miam.DataLayer;

namespace Miam.TestUtility.DbTestsHelperAPI
{
    public class DbTestHelper 
    {
        private IDbContextFactory<MiamDbContext> _dbContextFactory;

        public DbTestHelper(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public DatabaseDataHelper DatabaseDataHelper
        {
            get { return new DatabaseDataHelper(_dbContextFactory); }
        }
        public RestaurantTestHelper Restaurants
        {
            get { return new RestaurantTestHelper(_dbContextFactory); }
        }
        public WriterTestHelper Writers
        {
            get { return new WriterTestHelper(_dbContextFactory); }
        }
        public ReviewTestHelper Reviews
        {
            get { return new ReviewTestHelper(_dbContextFactory); }
        }
        public UserTestHelper User
        {
            get { return new UserTestHelper(_dbContextFactory); }
        }

        public RestaurantContactDetailTestHelper RestaurantContactDetails
        {
            get { return new RestaurantContactDetailTestHelper(_dbContextFactory); }
        }

        public TagTestHelper Tags
        {
            get { return new TagTestHelper(_dbContextFactory); }
        }
    }
}