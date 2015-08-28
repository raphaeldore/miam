using System.Web.Mvc;
using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Miam.Domain.Entities;

namespace Miam.Web.UnitTests.Controllers.RestaurantTests
{
    [TestClass]
    public class RestaurantControllerDeleteTests : BaseRestaurantControllerTests
    {
        [TestMethod]
        public void delete_restaurant_should_return_view_when_restaurantID_is_valid()
        {
            //Arrange 
            var restaurant = _fixture.Create<Restaurant>();
            RestaurantRepository.GetById(restaurant.Id).Returns(restaurant);

            //Action
            var result = RestaurantController.Delete(restaurant.Id) as ViewResult;
            var restaurantViewModel = result.ViewData.Model as ViewModels.Restaurant.RestaurantDeleteViewModel;

            //Assert 
            restaurantViewModel.ShouldBeEquivalentTo(restaurant); 
        }

        [TestMethod]
        public void delete_should_return_http_not_found_when_restaurantID_is_not_valid()
        {
            //Arrange 

            //Act
            var result = RestaurantController.Delete(999999999);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();

            // Même assertion, mais sans fluent assertion
            // Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult)); 
        }

        [TestMethod]
        public void delete_post_should_remove_restaurant()
        {
            //Arrange
            var restaurant = _fixture.Create<Restaurant>();
            RestaurantRepository.GetById(restaurant.Id).Returns(restaurant);


            //Action
            RestaurantController.DeleteConfirmed(restaurant.Id);

            // Assert
            RestaurantRepository.Received().Delete(restaurant);
        }

        [TestMethod]
        public void delete_post_should_redirect_to_index_on_success()
        {
            //Arrange
            var restaurant = _fixture.Create<Restaurant>();
            RestaurantRepository.GetById(restaurant.Id).Returns(restaurant);

            //Act
            var routeResult = RestaurantController.DeleteConfirmed(restaurant.Id) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            //Assert
            routeAction.ShouldBeEquivalentTo(MVC.Home.Views.ViewNames.Index);

        }
        [TestMethod]
        public void delete_post_should_return_http_not_found_when_restaurantID_is_not_valid()
        {
            //Arrange 

            //Act
            var result = RestaurantController.DeleteConfirmed(999999999);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }
         
        
        
    }
}