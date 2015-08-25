using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain;
using Miam.Domain.Entities;

namespace Miam.TestUtility.Database
{
    public class DataBaseTestHelper
    {
        //private int _writerID1;
        private Writer _writer1;
        private Writer _writer2;
        //private int _writerID2;
        private IEntityRepository<Restaurant> _restaurantRepository;
        private IEntityRepository<Writer> _writerRepository;
        private EfEntityRepository<ApplicationUser> _userRepository;

        public DataBaseTestHelper()
        {
            _restaurantRepository = new EfEntityRepository<Restaurant>();
            _writerRepository = new EfEntityRepository<Writer>();
            _userRepository = new EfEntityRepository<ApplicationUser>();
        }

        public void SeedTables()
        {
            AddWriter();
            AddRestaurants();
            AddAdmin();
        }

        private void AddAdmin()
        {
            var admin = TestData.ApplicationUserAdmin;
            _userRepository.Add(admin);
        }

        private void AddWriter()
        {
            _writer1 = TestData.Writer1;

            _writerRepository.Add(_writer1);
            //_writerID1 = writer1.Id;

            _writer2 = TestData.Writer2;
            _writerRepository.Add(_writer2);
            //_writerID2 = writer2.Id;
        }

        private void AddRestaurants()
        {
            AddRestaurant1WithReviewsAndTags();
            AddRestaurant2WithReviewsAndTags();
        }

       
        private void AddRestaurant1WithReviewsAndTags()
        {
            var restaurant = TestData.Restaurant1;

            //Add RestaurantContactDetail1 to _restaurant

            restaurant.RestaurantContactDetail = TestData.RestaurantContactDetail1;

            //Add tags to _restaurant
            restaurant.Tags.Add(TestData.Tag1);

            //Add reviews to _restaurant
            var review1 = TestData.Review1;
            review1.Writer = _writer1;
            restaurant.Reviews.Add(review1);

            var review2 = TestData.Review2;
            review2.Writer = _writer2;
            restaurant.Reviews.Add(review2);


            //Add _restaurant to database
            _restaurantRepository.Add(restaurant);
        }

        private void AddRestaurant2WithReviewsAndTags()
        {
            var restaurant = TestData.Restaurant2;

            //Add RestaurantContactDetail1 to _restaurant

            restaurant.RestaurantContactDetail = TestData.RestaurantContactDetail2;

            //Add tags to _restaurant
            restaurant.Tags.Add(TestData.Tag1);
            restaurant.Tags.Add(TestData.Tag2);

            //Add reviews to _restaurant
            var review1 = TestData.Review3;
            review1.Writer = _writer1;
            restaurant.Reviews.Add(review1);

            var review2 = TestData.Review1;
            review2.Writer = _writer2;
            restaurant.Reviews.Add(review2);


            //Add _restaurant to database
            _restaurantRepository.Add(restaurant);
        }

    }
}