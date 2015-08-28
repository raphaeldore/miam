using System;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
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

        private TestHelperApi _dbTestHelper;
        private EfEntityRepository<Writer> _writerRepository;
        private ApplicationContext applicationContext;
        private Restaurant _restaurant;
        private Writer _writer;
        private EfEntityRepository<Review> _reviewRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _dbTestHelper = new TestHelperApi(new DbContextFactory());
            _dbTestHelper.DataBase.ClearDataBaseTables();

            applicationContext = new ApplicationContext();
            _restaurantRepository = new EfEntityRepository<Restaurant>(applicationContext);
            _writerRepository = new EfEntityRepository<Writer>(applicationContext);
            _reviewRepository = new EfEntityRepository<Review>(applicationContext);

            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            _restaurant = _fixture.Create<Restaurant>();
            _writer = _fixture.Create<Writer>();
        }

        [TestMethod]
        public void add_restaurant()
        {
            //Arrange

            //Action
            _restaurantRepository.Add(_restaurant);

            //Assert 
            _dbTestHelper.Restaurants.Count().Should().Be(1);
        }

        [TestMethod]
        public void delete_restaurant()
        {
            //Arrange
            _dbTestHelper.Restaurants.Create(_restaurant);

            //Action
            var restaurantToDelete = _restaurantRepository.GetById(_restaurant.Id);
            _restaurantRepository.Delete(restaurantToDelete);

            //Assert 
            _dbTestHelper.Restaurants.Count().Should().Be(0);
        }

        [TestMethod]
        public void update_restaurant()
        {
            //Arrange 
            const string NEW_RESTAURANT_NAME = "Le lapin choqué";
            _dbTestHelper.Restaurants.Create(_restaurant);

            //Action
            var restaurantToUpdate = _restaurantRepository.GetById(_restaurant.Id);
            restaurantToUpdate.Name = NEW_RESTAURANT_NAME;
            _restaurantRepository.Update(restaurantToUpdate);

            //Assert 
            var restaurantAfter = _dbTestHelper.Restaurants.GetRestaurant(restaurantToUpdate);
            restaurantAfter.Name.Should().Be(NEW_RESTAURANT_NAME);
        }

        [TestMethod]
        public void update_restaurant_by_adding_review()
        {
            //Arrange 
            const string BODY_REVIEW = "Service exceptionnel. Ambiance décontractée";
            _dbTestHelper.Restaurants.Create(_restaurant);
            _dbTestHelper.Writer.Create(_writer);

            //ICI avec le ID ca marche !! ??
            var review = _fixture.Build<Review>()
                                 .With(x => x.Writer, _writer)
                                 .With(x => x.Restaurant, _restaurant)
                                 .With(x=>x.Body, BODY_REVIEW)
                                 .Create();
            
            //Action
            var restaurantToUpdate = _restaurantRepository.GetById(_restaurant.Id);
            restaurantToUpdate.Reviews.Add(review);
            _restaurantRepository.Update(restaurantToUpdate);

            //Assert 
            var reviewAfter = _dbTestHelper.Restaurants.GetFirstReviewOf(restaurantToUpdate);
            reviewAfter.Body.Should().Be(BODY_REVIEW);
        }


        [TestMethod]
        public void update_restaurant_review()
        {
            //Arrange 
            const string NEW_BODY_REVIEW = "Service exceptionnel. Ambiance décontractée";
            _dbTestHelper.Restaurants.Create(_restaurant);
            _dbTestHelper.Writer.Create(_writer);
            var review = _fixture.Build<Review>()
                                 .With(x => x.Writer, _writer)
                                 .With(x => x.Restaurant, _restaurant)
                                 .Create();
            _dbTestHelper.Reviews.Create(review);   

            //Action 
            review.Body = NEW_BODY_REVIEW;
            _reviewRepository.Update(review);
            
            //Assert 
            var reviewAfter = _dbTestHelper.Restaurants.GetFirstReviewOf(_restaurant);
            reviewAfter.Body.Should().Be(NEW_BODY_REVIEW);
        }

        [TestMethod]
        public void update_restaurant_contact_details()
        {
            //Arrange
            const string NEW_WEB_PAGE = "www.NewWebPage.com";
            _dbTestHelper.Restaurants.Create(_restaurant);

            var _restaurantContactDetail = _fixture.Build<RestaurantContactDetail>()
                                                   .With(x => x.RestaurantId, _restaurant.Id)
                                                   .Create();

            _dbTestHelper.RestaurantContactDetails.Create(_restaurantContactDetail);

            //Action
            var restaurantToUpdate = _restaurantRepository.GetById(_restaurant.Id);
            restaurantToUpdate.RestaurantContactDetail.WebPage = NEW_WEB_PAGE;
            _restaurantRepository.Update(restaurantToUpdate);

            //Assert 
            var contactDetailsAfter = _dbTestHelper.Restaurants.GetContactDetailOf(restaurantToUpdate);
            contactDetailsAfter.WebPage.Should().Be(NEW_WEB_PAGE);
        }


        [TestMethod]
        public void remove_restaurant_should_cascade_delete_reviews()
        {
            //Arrange
            _dbTestHelper.Restaurants.Create(_restaurant);
            _dbTestHelper.Writer.Create(_writer);
            var review = _fixture.Build<Review>()
                                 .With(x => x.Writer, _writer)
                                 .With(x => x.Restaurant, _restaurant)
                                 .Create();
            _dbTestHelper.Reviews.Create(review);

            //Action
            var restaurantToDelete = _restaurantRepository.GetById(_restaurant.Id);
            _restaurantRepository.Delete(restaurantToDelete);

            //Assert 
            _dbTestHelper.Reviews.Count().Should().Be(0);
        }

        [TestMethod]
        public void remove_restaurant_should_delete_restaurantContactDetail()
        {
            //Arrange
            _dbTestHelper.Restaurants.Create(_restaurant);
            var _restaurantContactDetail = _fixture.Build<RestaurantContactDetail>()
                                                   .With(x => x.Restaurant, _restaurant)
                                                   .Create();
            _dbTestHelper.RestaurantContactDetails.Create(_restaurantContactDetail);

            //Action
            var restaurantToDelete = _restaurantRepository.GetById(_restaurant.Id);
            _restaurantRepository.Delete(restaurantToDelete);

            //Assert
            _dbTestHelper.RestaurantContactDetails.Count().Should().Be(0);
        }

        [TestMethod]
        public void remove_restaurant_should_not_cascade_delete_tags()
        {
            //Arrange
            _dbTestHelper.Restaurants.Create(_restaurant);
            var tags = _fixture.CreateMany<Tag>();
            _dbTestHelper.Tags.Create(tags);

            //Action
            var restaurantToDelete = _restaurantRepository.GetById(_restaurant.Id);
            _restaurantRepository.Delete(restaurantToDelete);

            //Assert 
            int tagsCountAfter = _dbTestHelper.Tags.Count();
            tagsCountAfter.Should().Be(tags.Count());
        }
        [TestMethod]
        public void remove_writer_using_generic_repository_should_cascade_delete_reviews()
        {
            //Arrange
            _dbTestHelper.Writer.Create(_writer);
            _dbTestHelper.Restaurants.Create(_restaurant);
            var review = _fixture.Build<Review>()
                                 .With(x => x.Writer, _writer)
                                 .With(x => x.Restaurant, _restaurant)
                                 .Create();
            _dbTestHelper.Reviews.Create(review);   

            //Action
            var writerToDelete = _writerRepository.GetById(_writer.Id);
            _writerRepository.Delete(writerToDelete);
            
            //Assert 
            int reviewsCountAfter = _dbTestHelper.Reviews.Count();
            reviewsCountAfter.Should().Be(0);
        }
    }
}
