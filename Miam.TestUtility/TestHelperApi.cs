using Miam.DataLayer;
using Miam.TestUtility.TestsAPI;

namespace Miam.TestUtility
{
    public class TestHelperApi 
    {
        private ApplicationContext _applicationContext;

        public TestHelperApi(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;

        }
        public DatabaseHelper DataBase
        {
            get { return new DatabaseHelper(); }
        }
        public RestaurantTestHelperApi Restaurant
        {
            get { return new RestaurantTestHelperApi(_applicationContext); }
        }
        public WriterTestHelper Writer
        {
            get { return new WriterTestHelper(_applicationContext); }
        }
        public ReviewTestHelper Review
        {
            get {return new ReviewTestHelper(_applicationContext);}
        }
        public UserAcceptanceTestsApi User
        {
            get { return new UserAcceptanceTestsApi(_applicationContext); }
        }
    }
}