using System.Data.Entity.Infrastructure;
using Miam.DataLayer;

namespace Miam.TestUtility.TestsAPI
{
    public class TestHelperApi 
    {
        private IDbContextFactory<MiamDbContext> _dbContextFactory;

        public TestHelperApi(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public DatabaseHelper DataBase
        {
            get { return new DatabaseHelper(new ApplicationContext()); }
        }
        public RestaurantTestHelper Restaurants
        {
            get { return new RestaurantTestHelper(_dbContextFactory); }
        }
        public WriterTestHelper Writer
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