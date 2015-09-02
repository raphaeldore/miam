using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Restaurant;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.Controllers.RestaurantTests
{
    [TestClass]
    public class RestaurantControllerEditTests : BaseRestaurantControllerTests
    {
        [TestMethod]
        public void edit_should_return_view_with_restaurantViewModel_when_restaurantId_is_valid()
        {
            //Arrange 
            var restaurant = _fixture.Create<Restaurant>();
            RestaurantRepository.GetById(restaurant.Id).Returns(restaurant);
            var viewModelExpected = Mapper.Map<RestaurantEditViewModel>(restaurant);

            //Action
            var viewResult = RestaurantController.Edit(restaurant.Id) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as RestaurantEditViewModel;

            //Assert 
            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected);
        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_restaurantID_is_not_valid()
        {
            //Arrange 

            //Act
            var result = RestaurantController.Edit(999999999);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();

            // Même assertion, mais sans fluent assertion
            // Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult)); 

        }


        [TestMethod]
        public void edit_post_should_update_restaurant_when_restaurantId_is_valid()
        {
            //Arrange
            var restaurant = _fixture.Create<Restaurant>();
            RestaurantRepository.GetById(restaurant.Id).Returns(restaurant);
            var restaurantViewModel = Mapper.Map<RestaurantEditViewModel>(restaurant);

            //Action
            var actionResult = RestaurantController.Edit(restaurantViewModel);

            // Assert
            RestaurantRepository.Received().Update(Arg.Is<Restaurant>(x => x.Id == restaurant.Id));

        }

        [TestMethod]
        public void edit_post_should_redirect_to_index_on_success()
        {
            //Arrange
            var restaurant = _fixture.Create<Restaurant>();
            RestaurantRepository.GetById(restaurant.Id).Returns(restaurant);
            var restaurantEditPageViewModel = Mapper.Map<RestaurantEditViewModel>(restaurant);

            //Act
            var routeResult = RestaurantController.Edit(restaurantEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            //Assert
            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);

        }

        [TestMethod]
        public void edit_post_should_return_default_view_when_modelState_is_not_valid()
        {
            //Arrange
            var restaurant = _fixture.Create<Restaurant>();
            var restaurantViewModel = _fixture.Build<RestaurantEditViewModel>()
                                                      .With(x => x.Id, restaurant.Id)
                                                      .Create();
            RestaurantRepository.GetById(restaurant.Id).Returns(restaurant);
            RestaurantController.ModelState.AddModelError("Error", "Error");

            //Act
            var result = RestaurantController.Edit(restaurantViewModel) as ViewResult;

            //Assert
            Assert.AreEqual(result.ViewName, "");

        }
        [TestMethod]
        public void edit_post_should_return_http_not_found_when_restaurantID_is_not_valid()
        {
            //Arrange 
            var restaurantViewModel = _fixture.Create<RestaurantEditViewModel>();
            RestaurantRepository.GetById(Arg.Any<int>()).Returns(x => null);

            //Act
            var result = RestaurantController.Edit(restaurantViewModel);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}