using System.Linq;
using FluentAssertions;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.DataLayer.IntegrationTests.GenericRepositoryTests
{

    [TestClass]
    public class RestaurantRepositoryTests : BaseRepositoryTests
    {
        private EfEntityRepository<Restaurant> _restaurantRepository;
        private Restaurant _restaurant;
        private Writer _writer;

        [TestInitialize]
        public void TestInitialize()
        {
            _restaurantRepository = new EfEntityRepository<Restaurant>(new ApplicationContext());

            _restaurant = Fixture.Create<Restaurant>();
            _writer = Fixture.Create<Writer>();
        }

        [TestMethod]
        public void add_restaurant()
        {
            //Arrange

            //Action
            _restaurantRepository.Add(_restaurant);

            //Assert 
            DbTestHelper.Restaurants.Count().Should().Be(1);
        }

        [TestMethod]
        public void delete_restaurant()
        {
            //Arrange
            DbTestHelper.Restaurants.Create(_restaurant);

            //Action
            var restaurantToDelete = _restaurantRepository.GetById(_restaurant.Id);
            _restaurantRepository.Delete(restaurantToDelete);

            //Assert 
            DbTestHelper.Restaurants.Count().Should().Be(0);
        }

        [TestMethod]
        public void update_restaurant()
        {
            //Arrange 
            const string NEW_RESTAURANT_NAME = "Le lapin choqué";
            DbTestHelper.Restaurants.Create(_restaurant);

            //Action
            var restaurantToUpdate = _restaurantRepository.GetById(_restaurant.Id);
            restaurantToUpdate.Name = NEW_RESTAURANT_NAME;
            _restaurantRepository.Update(restaurantToUpdate);

            //Assert 
            var restaurantAfter = DbTestHelper.Restaurants.GetRestaurant(restaurantToUpdate);
            restaurantAfter.Name.Should().Be(NEW_RESTAURANT_NAME);
        }

        [TestMethod]
        public void update_restaurant_by_adding_review()
        {
            //Arrange 
            const string BODY_REVIEW = "Service exceptionnel. Ambiance décontractée";
            DbTestHelper.Restaurants.Create(_restaurant);
            DbTestHelper.Writer.Create(_writer);

            var review = Fixture.Build<Review>()
                                 .With(x => x.WriterId, _writer.Id)
                                 .With(x => x.RestaurantId, _restaurant.Id)
                                 .With(x => x.Body, BODY_REVIEW)
                                 .Create();

            //Action
            var restaurantToUpdate = _restaurantRepository.GetById(_restaurant.Id);
            restaurantToUpdate.Reviews.Add(review);
            _restaurantRepository.Update(restaurantToUpdate);

            //Assert 
            var reviewAfter = DbTestHelper.Restaurants.GetFirstReviewOf(restaurantToUpdate);
            reviewAfter.Body.Should().Be(BODY_REVIEW);
        }


        [TestMethod]
        public void update_restaurant_review()
        {
            //Arrange 
            const string NEW_BODY_REVIEW = "Service exceptionnel. Ambiance décontractée";
            DbTestHelper.Restaurants.Create(_restaurant);
            DbTestHelper.Writer.Create(_writer);
            var review = Fixture.Build<Review>()
                                 .With(x => x.WriterId, _writer.Id)
                                 .With(x => x.RestaurantId, _restaurant.Id)
                                 .Create();
            DbTestHelper.Reviews.Create(review);

            //Action 
            var restaurantToUpdate = _restaurantRepository.GetById(_restaurant.Id);
            restaurantToUpdate.Reviews.First().Body = NEW_BODY_REVIEW;
            _restaurantRepository.Update(restaurantToUpdate);

            //Assert 
            var reviewAfter = DbTestHelper.Restaurants.GetFirstReviewOf(_restaurant);
            reviewAfter.Body.Should().Be(NEW_BODY_REVIEW);
        }

        [TestMethod]
        public void update_restaurant_contact_details()
        {
            //Arrange
            const string NEW_WEB_PAGE = "www.NewWebPage.com";
            DbTestHelper.Restaurants.Create(_restaurant);

            var restaurantContactDetail = Fixture.Build<RestaurantContactDetail>()
                                                   .With(x => x.RestaurantId, _restaurant.Id)
                                                   .Create();

            DbTestHelper.RestaurantContactDetails.Create(restaurantContactDetail);

            //Action
            var restaurantToUpdate = _restaurantRepository.GetById(_restaurant.Id);
            restaurantToUpdate.RestaurantContactDetail.WebPage = NEW_WEB_PAGE;
            _restaurantRepository.Update(restaurantToUpdate);

            //Assert 
            var contactDetailsAfter = DbTestHelper.Restaurants.GetContactDetailOf(restaurantToUpdate);
            contactDetailsAfter.WebPage.Should().Be(NEW_WEB_PAGE);
        }


        [TestMethod]
        public void remove_restaurant_should_cascade_delete_reviews()
        {
            //Arrange
            DbTestHelper.Restaurants.Create(_restaurant);
            DbTestHelper.Writer.Create(_writer);
            var review = Fixture.Build<Review>()
                                 .With(x => x.WriterId, _writer.Id)
                                 .With(x => x.RestaurantId, _restaurant.Id)
                                 .Create();
            DbTestHelper.Reviews.Create(review);

            //Action
            var restaurantToDelete = _restaurantRepository.GetById(_restaurant.Id);
            _restaurantRepository.Delete(restaurantToDelete);

            //Assert 
            DbTestHelper.Reviews.Count().Should().Be(0);
        }

        [TestMethod]
        public void remove_restaurant_should_delete_restaurantContactDetail()
        {
            //Arrange
            DbTestHelper.Restaurants.Create(_restaurant);
            var _restaurantContactDetail = Fixture.Build<RestaurantContactDetail>()
                                                   .With(x => x.RestaurantId, _restaurant.Id)
                                                   .Create();
            DbTestHelper.RestaurantContactDetails.Create(_restaurantContactDetail);

            //Action
            var restaurantToDelete = _restaurantRepository.GetById(_restaurant.Id);
            _restaurantRepository.Delete(restaurantToDelete);

            //Assert
            DbTestHelper.RestaurantContactDetails.Count().Should().Be(0);
        }

        [TestMethod]
        public void remove_restaurant_should_not_cascade_delete_tags()
        {
            //Arrange
            DbTestHelper.Restaurants.Create(_restaurant);
            var tags = Fixture.CreateMany<Tag>();
            DbTestHelper.Tags.Create(tags);

            //Action
            var restaurantToDelete = _restaurantRepository.GetById(_restaurant.Id);
            _restaurantRepository.Delete(restaurantToDelete);

            //Assert 
            int tagsCountAfter = DbTestHelper.Tags.Count();
            tagsCountAfter.Should().Be(tags.Count());
        }
    }
}
