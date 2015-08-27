using System;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;
using Miam.TestUtility;
using Miam.TestUtility.AutoFixture;
using Miam.TestUtility.Database;
using Miam.TestUtility.TestsAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.DataLayer.IntegrationTests.GenericRepositoryTests
{

    [TestClass]
    public class GenericRepositoryTests
    {
        private Fixture _fixture;
        private EfEntityRepository<Restaurant> _restaurantRepository;
        private EfApplicationDatabaseHelper _ApplicationDataBaseHelper;



        private ReviewTestHelper _integrationTestsHelper;
        private TestHelperApi _dbTestHelper;
        private EfEntityRepository<Writer> _writerRepository;
        private ApplicationContext applicationContext;

        [TestInitialize]
        public void TestInitialize()
        {
            //_ApplicationDataBaseHelper = new EfApplicationDatabaseHelper(new ApplicationContext());
            //_ApplicationDataBaseHelper.MigrateDatabaseToLatestVersion();
            //_ApplicationDataBaseHelper.ClearAllTables();

            _dbTestHelper  = new TestHelperApi(new ApplicationContext());
            _dbTestHelper.DataBase.ClearDataBaseTables();
            

            applicationContext = new ApplicationContext();
            _restaurantRepository = new EfEntityRepository<Restaurant>(applicationContext);
            _writerRepository = new EfEntityRepository<Writer>(applicationContext);

            
            

            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());
        }

        [TestMethod]
        public void add_and_commit_restaurant_using_generic_repository()
        {
            //Arrange
            int restaurantCountExpected = _dbTestHelper.Restaurant.GetRestaurantCount() + 1;
            var newRestaurant = _fixture.Create<Restaurant>();

            //Action
            _restaurantRepository.Add(newRestaurant);

            //Assert 
            var restaurantCountAfterAdd = _dbTestHelper.Restaurant.GetRestaurantCount();
            Assert.AreEqual(restaurantCountExpected, restaurantCountAfterAdd);
        }

        [TestMethod]
        public void delete_and_commit_restaurant_using_generic_repository()
        {
            //Arrange
            var restaurant = _dbTestHelper.Restaurant.Create();
            var restaurantCountExpected = _dbTestHelper.Restaurant.GetRestaurantCount() - 1;

            //Action
            var resto =  _restaurantRepository.GetById(restaurant.Id);
            _restaurantRepository.Delete(resto);

            //Assert 
            var restaurantCountAfter = _dbTestHelper.Restaurant.GetRestaurantCount();
            Assert.AreEqual(restaurantCountExpected, restaurantCountAfter);
        }

        [TestMethod]
        public void update_restaurant_using_generic_reposiotry()
        {
            //Arrange 
            const string NEW_RESTAURANT_NAME = "Le lapin choqué";
            var restaurant = _dbTestHelper.Restaurant.Create();

            //Action
            restaurant = _restaurantRepository.GetById(restaurant.Id);
            restaurant.Name = NEW_RESTAURANT_NAME;
            _restaurantRepository.Update(restaurant);

            //Assert 
            var restaurantAfter = _dbTestHelper.Restaurant.GetRestaurant(restaurant);
            Assert.AreEqual(NEW_RESTAURANT_NAME, restaurantAfter.Name);

        }

        [TestMethod]
        public void update_restaurant_by_adding_review_using_generic_repository()
        {
            //Arrange 
            var restaurant = _dbTestHelper.Restaurant.Create();
            var restaurantReviewsCountExpected = restaurant.Reviews.Count() + 1;
            var writer = _dbTestHelper.Writer.Create();

            //Action 
            var writerInDatabase = _writerRepository.GetById(writer.Id);
            var restaurantInDatabase = _restaurantRepository.GetById(restaurant.Id);

            var review = _fixture.Build<Review>()
                                 .With(x => x.Writer, writerInDatabase)
                                 .With(x => x.Restaurant, restaurantInDatabase)
                                 .Create();

            restaurantInDatabase.Reviews.Add(review);
            _restaurantRepository.Update(restaurantInDatabase);
            //ou
            //writer.Reviews.Add(review);
            //_writerRepository.Update(writer);

            //Assert 
            var restaurantReviewsCountAfter = _dbTestHelper.Review.GetReviewsCount(restaurantInDatabase);
            Assert.AreEqual(restaurantReviewsCountExpected,  restaurantReviewsCountAfter);
        }


        //[TestMethod]
        //public void update_restaurant_review_using_generic_repository()
        //{
        //    //Arrange 
        //    const string NEW_BODY_REVIEW = "Service exceptionnel. Ambiance décontractée";
        //    //Arrange 
        //    var restaurant = _integrationTestsHelper.Create();
        //    var review = _integrationTestsHelper.Create();
        //    var writer = _integrationTestsHelper.Create();

        //    //Action 
        //    var writerInDatabase = _writerRepository.GetById(writer.Id);
        //    var restaurantInDatabase = _restaurantRepository.GetById(restaurant.Id);

        //    var review = _fixture.Build<Review>()
        //                         .With(x => x.Writer, writerInDatabase)
        //                         .With(x => x.Restaurant, restaurantInDatabase)
        //                         .Create();

        //    restaurantInDatabase.Reviews.Add(review);
        //    _restaurantRepository.Update(restaurantInDatabase);
            //ou
            //writer.Reviews.Add(review);
            //_writerRepository.Update(writer);

            //Assert 
            //var restaurantReviewsCountAfter = _integrationTestsHelper.GetReviewsCount(restaurantInDatabase);
            //Assert.AreEqual(restaurantReviewsCountExpected, restaurantReviewsCountAfter);
       // }

        //[TestMethod]
        //public void update_restaurant_restaurtantContactDetail_using_generic_repository()
        //{
        //    //Arrange
        //    const string NEW_WEB_PAGE = "www.NewWebPage.com";
        //    var restaurantBefore = _miamDbContextBefore.Restaurants.First();

        //    //Action
        //    var restaurantToUpdate = _restaurantRepository.GetById(restaurantBefore.Id);
        //    restaurantToUpdate.RestaurantContactDetail.WebPage = NEW_WEB_PAGE;
        //    _restaurantRepository.Update(restaurantToUpdate);

        //    //Assert 
        //    var restaurantAfter = _miamDbContextAfter.Restaurants
        //        .Single(r => r.Id == restaurantBefore.Id);
        //    Assert.AreEqual(NEW_WEB_PAGE, restaurantAfter.RestaurantContactDetail.WebPage);
        //}


        //[TestMethod]
        //public void remove_restaurant_using_generic_repository_should_cascade_delete_reviews()
        //{
        //    //Arrange
        //    var restaurantBefore = _miamDbContextBefore.Restaurants.First();


        //    //Action
        //    var restaurantToDelete = _restaurantRepository.GetById(restaurantBefore.Id);
        //    _restaurantRepository.Delete(restaurantToDelete);

        //    //Assert 
        //    int reviewsCountAfter = _miamDbContextAfter.Reviews
        //        .Count(r => r.Restaurant.Id == restaurantBefore.Id);
        //    Assert.AreEqual(0, reviewsCountAfter);
        //}

        //[TestMethod]
        //public void remove_restaurant_using_generic_repository_should_delete_restaurantContactDetail()
        //{
        //    //Arrange
        //    var restaurantBefore = _miamDbContextBefore.Restaurants.First();
        //    int restaurantContactDetailsCountBefore = _miamDbContextBefore.RestaurantContactDetails
        //        .Count(r => r.RestaurantId == restaurantBefore.Id);

        //    //Action
        //    var restaurantToDelete = _restaurantRepository.GetById(restaurantBefore.Id);
        //    _restaurantRepository.Delete(restaurantToDelete);

        //    //Assert
        //    int restaurantContactDetailsCountAfter = _miamDbContextAfter.RestaurantContactDetails
        //        .Count(r => r.RestaurantId == restaurantBefore.Id);
        //    Assert.AreEqual(restaurantContactDetailsCountBefore - 1, restaurantContactDetailsCountAfter);
        //}

        //[TestMethod]
        //public void remove_restaurant_using_generic_repository_should_not_cascade_delete_tags()
        //{
        //    //Arrange
        //    var restaurantBefore = _miamDbContextBefore.Restaurants.First();
        //    int tagsCountBefore = _miamDbContextBefore.RestaurantTags.Count();

        //    //Action
        //    var restaurantToDelete = _restaurantRepository.GetById(restaurantBefore.Id);
        //    _restaurantRepository.Delete(restaurantToDelete);

        //    //Assert 
        //    int tagsCountAfter = _miamDbContextAfter.RestaurantTags.Count();
        //    Assert.AreEqual(tagsCountBefore, tagsCountAfter);
        //}
        //[TestMethod]
        //public void remove_writer_using_generic_repository_should_cascade_delete_reviews()
        //{
        //    //Arrange
        //    var writerRepository = new EfEntityRepository<Writer>(new ApplicationContext());
        //    var writerBefore = _miamDbContextBefore.Writers.First();

        //    //Action
        //    var writer = writerRepository.GetById(writerBefore.Id);
        //    writerRepository.Delete(writer);

        //    //Assert 
        //    int reviewsCountAfter = _miamDbContextAfter.Reviews.Count(r => r.Writer.Id == writer.Id);
        //    Assert.AreEqual(0, reviewsCountAfter);
      //  }
    }
}
