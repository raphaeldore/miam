using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.Web.Controllers;
using Miam.Web.Services;
using Miam.Web.ViewModels.Review;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.Controllers.ReviewTests
{
    [TestClass]
    public class ReviewControllerTests : AllControllersBaseClassTests
    {
        private ReviewController _reviewController;
        private IEntityRepository<Restaurant> _restaurantRepository;
        private IHttpContextService _httpContextService;
        private IEntityRepository<Writer> _writerRepository;

        [TestInitialize]
        public void ReviewControllerTestInit()
        {
            _writerRepository = Substitute.For<IEntityRepository<Writer>>();
            _restaurantRepository = Substitute.For<IEntityRepository<Restaurant>>();
            _httpContextService = Substitute.For<IHttpContextService>();
            _reviewController = new ReviewController(_restaurantRepository,
                                                     _writerRepository,
                                                     _httpContextService);
        }

        [TestMethod]
        public void create_action_should_render_default_view()
        {
            var result = _reviewController.Create() as ViewResult;

            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void create_post_should_add_writer_review_to_repository()
        {
            // Arrange   
            var writer = _fixture.Create<Writer>();
            var restaurant = _fixture.Create<Restaurant>();
            var review = _fixture.Build<Review>()
                                 .With(x => x.Writer, writer)
                                 .With(x => x.Restaurant, restaurant)
                                 .Create();

            var reviewViewModel = Mapper.Map<Create>(review);

            _writerRepository.GetById(Arg.Any<int>()).Returns(review.Writer);
            _restaurantRepository.GetById(Arg.Any<int>()).Returns(review.Restaurant);

            // Action
            _reviewController.Create(reviewViewModel);

            // Assert
            ReviewRepositoryAddMethodShouldHaveReceived(review);
        }

        [TestMethod]
        public void create_post_should_return_view_with_errors_when_modelState_is_not_valid()
        {
            //Arrange
            var reviewCreateViewModel = _fixture.Build<Create>()
                                                .Without(x => x.Restaurants)
                                                .Create();
            _reviewController.ModelState.AddModelError("Error", "Error");

            //Act
            var result = _reviewController.Create(reviewCreateViewModel) as ViewResult;
            var viewName = result.ViewName;

            //Assert
            viewName.Should().Be("");
        }

        [TestMethod]
        public void create_post_should_redirect_to_home_index_on_success()
        {
            //Arrange
            var writer = _fixture.Create<Writer>();
            var reviewCreateViewModel = _fixture.Build<Create>()
                                                .Without(x => x.Restaurants)
                                                .Create();

            _writerRepository.GetById(Arg.Any<int>()).Returns(writer);

            //Action
            var result = _reviewController.Create(reviewCreateViewModel) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            //Assert
            action.ShouldBeEquivalentTo(MVC.Home.Views.ViewNames.Index);

        }
        private void ReviewRepositoryAddMethodShouldHaveReceived(Review review)
        {
            _writerRepository.Received().Update(Arg.Is<Writer>(x => x.Reviews.First().Body == review.Body));
            _writerRepository.Received().Update(Arg.Is<Writer>(x => x.Reviews.First().Writer == review.Writer));
            _writerRepository.Received().Update(Arg.Is<Writer>(x => x.Reviews.First().Restaurant == review.Restaurant));
        }


    }
}
