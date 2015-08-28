using System.Data.Entity.Infrastructure;
using Miam.DataLayer;
using Miam.TestUtility.TestsAPI;

namespace Miam.TestUtility
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
        public RestaurantTestHelperApi Restaurants
        {
            get { return new RestaurantTestHelperApi(_dbContextFactory); }
        }
        public WriterTestHelper Writer
        {
            get { return new WriterTestHelper(_dbContextFactory); }
        }
        public ReviewTestHelper Reviews
        {
            get { return new ReviewTestHelper(_dbContextFactory); }
        }
        public UserAcceptanceTestsApi User
        {
            get { return new UserAcceptanceTestsApi(_dbContextFactory); }
        }

        public RestaurantContactDetailTestsApi RestaurantContactDetails
        {
            get { return new RestaurantContactDetailTestsApi(_dbContextFactory); }
        }

        public TagTestApi Tags
        {
            get { return new TagTestApi(_dbContextFactory); }
        }
    }
}