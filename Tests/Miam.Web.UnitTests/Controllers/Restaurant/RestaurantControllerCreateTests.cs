using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Miam.DataLayer;
using Miam.Web.Controllers;
using Miam.Web.ViewModels.RestaurantViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Miam.Domain;
using Miam.Domain.Entities;

namespace Miam.Web.UnitTests.Controllers.Home
{
    [TestClass]
    public class RestControllerCreateTests : ControllerBaseTestsClass
    {
        private IEntityRepository<Restaurant> _restaurantRepository;
        private RestaurantController _restaurantController;

        [TestInitialize]
        public void RestaurantControllerTestInit()
        {
            _restaurantRepository = Substitute.For<IEntityRepository<Restaurant>>();
            _restaurantController = new RestaurantController(_restaurantRepository);
        }

        [TestMethod]
        public void create_action_should_render_default_view()
        {
            var result = _restaurantController.Create() as ViewResult;

            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void post_create_should_add_restaurant_to_repository()
        {
            // Arrange   
            var restaurant = _fixture.Create<Restaurant>();
            var restaurantViewModel = Mapper.Map<RestaurantCreateViewModel>(restaurant);

            // Action
            _restaurantController.Create(restaurantViewModel);

            // Assert (avec NSubstitute)
            _restaurantRepository.Received().Add(Arg.Is<Restaurant>(x => x.Id == restaurant.Id));
        }

        [TestMethod]
        public void post_create_should_return_view_with_errors_when_modelState_is_not_valid()
        {
            //Arrange
            var restaurantViewModel = _fixture.Create<RestaurantCreateViewModel>();
            _restaurantController.ModelState.AddModelError("Error", "Error");

            //Act
            var result = _restaurantController.Create(restaurantViewModel) as ViewResult;
            var viewName = result.ViewName;

            //Assert

            viewName.Should().Be("");
        }

        [TestMethod]
        public void post_create_should_redirect_to_index_on_success()
        {
            //Arrange
            var restaurantViewModel = _fixture.Create<RestaurantCreateViewModel>();

            //Act
            var result = _restaurantController.Create(restaurantViewModel) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];


            //Assert
            action.ShouldBeEquivalentTo(MVC.Home.Views.ViewNames.Index);

        }

    }
}

