using System.Linq;
using Miam.Domain.Entities;
using Miam.TestUtility.AutoFixture;
using Miam.TestUtility.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.DataLayer.IntegrationTests.GenericRepositoryTests
{

    [TestClass]
    public class GenericRepositoryTests
    {
        private Fixture _fixture;
        private EfEntityRepository<Restaurant> _restaurantRepository;
        private DataBaseTestHelper _dataBaseTestHelper;
        private EfDatabaseHelper _dataBaseHelper;

        private MiamDbContext _miamDbContextAfter;
        private MiamDbContext _miamDbContextBefore;

        [TestInitialize]
        public void TestInitialize()
        {
            _dataBaseHelper = new EfDatabaseHelper();
            _dataBaseHelper.DropCreateDatabaseIfModelChanges();
            _dataBaseHelper.DeleteAll();

            _dataBaseTestHelper = new DataBaseTestHelper();
            _dataBaseTestHelper.SeedTables();

            _miamDbContextBefore = new MiamDbContext();
            _miamDbContextAfter = new MiamDbContext();
            _restaurantRepository = new EfEntityRepository<Restaurant>();

            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());
        }

        [TestMethod]
        public void add_and_commit_restaurant_using_generic_repository()
        {
            //Arrange
            int restaurantCount = _miamDbContextBefore.Restaurants.Count();
            var newRestaurant = _fixture.Create<Restaurant>();

            //Action
            _restaurantRepository.Add(newRestaurant);

            //Assert 
            var restaurantCountAfter = _miamDbContextAfter.Restaurants.Count();
            Assert.AreEqual(restaurantCount + 1, restaurantCountAfter);
        }

        [TestMethod]
        public void deleteById_and_commit_restaurant_using_generic_repository()
        {
            //Arrange
            int restaurantCount = _miamDbContextBefore.Restaurants.Count();
            var restaurantToDelete = _miamDbContextBefore.Restaurants.First();

            //Action
            _restaurantRepository.DeleteById(restaurantToDelete.Id);

            //Assert 
            var restaurantCountAfter = _miamDbContextAfter.Restaurants.Count();
            Assert.AreEqual(restaurantCount - 1, restaurantCountAfter);
        }

        [TestMethod]
        public void update_restaurant_using_generic_reposiotry()
        {
            //Arrange 

            const string NEW_RESTAURANT_NAME = "Le lapin choqué";
            var restaurantBefore = _miamDbContextBefore.Restaurants.First();

            //Action
            var restaurantToUpdate = _restaurantRepository.GetById(restaurantBefore.Id);
            restaurantToUpdate.Name = NEW_RESTAURANT_NAME;
            _restaurantRepository.Update(restaurantToUpdate);

            //Assert 

            var restaurantAfter = _miamDbContextAfter.Restaurants.FirstOrDefault(x => x.Id == restaurantBefore.Id);
            Assert.AreEqual(NEW_RESTAURANT_NAME, restaurantAfter.Name);
            
        }

        [TestMethod]
        public void update_restaurant_by_adding_review_using_generic_repository()
        {
            //Arrange 
            var restaurantBefore = _miamDbContextBefore.Restaurants.First();
            var writer = _miamDbContextBefore.Writers.First();
            int restaurantReviewsCountBefore = restaurantBefore.Reviews.Count();

            var newReview = _fixture.Build<Review>()
                .With(r => r.WriterId, writer.Id)
                .With(r => r.Id, restaurantBefore.Id)
                .Create();

            //Action
            var restaurantToUpdate = _restaurantRepository.GetById(restaurantBefore.Id);
            restaurantToUpdate.Reviews.Add(newReview);
            _restaurantRepository.Update(restaurantToUpdate);

            //Assert 
            int restaurantReviewsCountAfter = _miamDbContextAfter.Reviews
             .Count(r => r.RestaurantId == restaurantBefore.Id);
            Assert.AreEqual(restaurantReviewsCountBefore + 1, restaurantReviewsCountAfter);
        }


        [TestMethod]
        public void query_restaurant_that_start_with_letter_z_using_generic_repository()
        {
            //Arrange 
            var newRestaurant = _fixture.Build<Restaurant>()
                .With(r => r.Name, "zoom thai")
                .Create();
            _miamDbContextBefore.Restaurants.Add(newRestaurant);
            _miamDbContextBefore.SaveChanges();

            //Action
            var restaurants = _restaurantRepository.GetAll().Where(r => r.Name.StartsWith("z"));

            //Assert 
            Assert.AreEqual(restaurants.Count(), 1);
        }

        [TestMethod]
        public void update_restaurant_review_using_generic_repository()
        {
            //Arrange 
            const string NEW_BODY_REVIEW = "Service exceptionnel. Ambiance décontractée";
            var restaurantBefore = _miamDbContextBefore.Restaurants.First();

            //Action
            var restaurantToUpdate = _restaurantRepository.GetById(restaurantBefore.Id);
            restaurantToUpdate.Reviews.ElementAt(0).Body = NEW_BODY_REVIEW;
            _restaurantRepository.Update(restaurantToUpdate);

            //Assert 
            var restaurantAfter = _miamDbContextAfter.Restaurants
                .First(r => r.Id == restaurantBefore.Id);
            Assert.AreEqual(NEW_BODY_REVIEW, restaurantAfter.Reviews.ElementAt(0).Body);
        }

        [TestMethod]
        public void update_restaurant_restaurtantContactDetail_using_generic_repository()
        {
            //Arrange
            const string NEW_WEB_PAGE = "www.NewWebPage.com";
            var restaurantBefore = _miamDbContextBefore.Restaurants.First();

            //Action
            var restaurantToUpdate = _restaurantRepository.GetById(restaurantBefore.Id);
            restaurantToUpdate.RestaurantContactDetail.WebPage = NEW_WEB_PAGE;
            _restaurantRepository.Update(restaurantToUpdate);

            //Assert 
            var restaurantAfter = _miamDbContextAfter.Restaurants
                .Single(r => r.Id == restaurantBefore.Id);
            Assert.AreEqual(NEW_WEB_PAGE, restaurantAfter.RestaurantContactDetail.WebPage);
        }


        [TestMethod]
        public void remove_restaurant_using_generic_repository_should_cascade_delete_reviews()
        {
            //Arrange
            var restaurantBefore = _miamDbContextBefore.Restaurants.First();

            //Action
            _restaurantRepository.DeleteById(restaurantBefore.Id);

            //Assert 
            int reviewsCountAfter = _miamDbContextAfter.Reviews
                .Count(r => r.RestaurantId == restaurantBefore.Id);
            Assert.AreEqual(0, reviewsCountAfter);
        }

        [TestMethod]
        public void remove_restaurant_using_generic_repository_should_delete_restaurantContactDetail()
        {
            //Arrange
            var restaurantBefore = _miamDbContextBefore.Restaurants.First();
            int restaurantContactDetailsCountBefore = _miamDbContextBefore.RestaurantContactDetails
                .Count(r => r.RestaurantId == restaurantBefore.Id);

            //Action
            _restaurantRepository.DeleteById(restaurantBefore.Id);

            //Assert
            int restaurantContactDetailsCountAfter = _miamDbContextAfter.RestaurantContactDetails
                .Count(r => r.RestaurantId == restaurantBefore.Id);
            Assert.AreEqual(restaurantContactDetailsCountBefore - 1, restaurantContactDetailsCountAfter);
        }

        [TestMethod]
        public void remove_restaurant_using_generic_repository_should_not_cascade_delete_tags()
        {
            //Arrange
            var restaurantBefore = _miamDbContextBefore.Restaurants.First();
            int tagsCountBefore = _miamDbContextBefore.RestaurantTags.Count();

            //Action
            _restaurantRepository.DeleteById(restaurantBefore.Id);

            //Assert 
            int tagsCountAfter = _miamDbContextAfter.RestaurantTags.Count();
            Assert.AreEqual(tagsCountBefore, tagsCountAfter);
        }
        [TestMethod]
        public void remove_writer_using_generic_repository_should_cascade_delete_reviews()
        {
            //Arrange
            var writerRepository = new EfEntityRepository<Writer>();
            var writerBefore = _miamDbContextBefore.Writers.First();

            //Action
            var writer = writerRepository.GetById(writerBefore.Id);
            writerRepository.DeleteById(writer.Id);

            //Assert 
            int reviewsCountAfter = _miamDbContextAfter.Reviews
                .Count(r => r.WriterId == writer.Id);
            Assert.AreEqual(0, reviewsCountAfter);
        }
    }
}
