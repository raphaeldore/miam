using System.Web.Mvc;
using FluentAssertions;
using Miam.Web.ViewModels.RestaurantViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Miam.Domain.Entities;

namespace Miam.Web.UnitTests.Controllers.RestaurantTests
{
    [TestClass]
    public class RestaurantControllerDeleteTests : RestaurantControllerBaseClassTests
    {
        [TestMethod]
        public void delete_restaurant_should_return_view_when_restaurantID_is_valid()
        {
            //Arrange 
            var restaurant = _fixture.Create<Restaurant>();
            _restaurantRepository.GetById(restaurant.Id).Returns(restaurant);

            //Action
            var result = _restaurantController.Delete(restaurant.Id) as ViewResult;
            var restaurantViewModel = result.ViewData.Model as RestaurantDeleteViewModel;

            //Assert 
            restaurantViewModel.ShouldBeEquivalentTo(restaurant); 
        }

        [TestMethod]
        public void delete_should_return_http_not_found_when_restaurantID_is_not_valid()
        {
            //Arrange 

            //Act
            var result = _restaurantController.Delete(999999999);

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
            _restaurantRepository.GetById(restaurant.Id).Returns(restaurant);


            //Action
            _restaurantController.DeleteConfirmed(restaurant.Id);

            // Assert
            _restaurantRepository.Received().Delete(restaurant);
        }

        [TestMethod]
        public void delete_post_should_redirect_to_index_on_success()
        {
            //Arrange
            var restaurant = _fixture.Create<Restaurant>();
            _restaurantRepository.GetById(restaurant.Id).Returns(restaurant);

            //Act
            var routeResult = _restaurantController.DeleteConfirmed(restaurant.Id) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            //Assert
            routeAction.ShouldBeEquivalentTo(MVC.Home.Views.ViewNames.Index);

        }
        [TestMethod]
        public void delete_post_should_return_http_not_found_when_restaurantID_is_not_valid()
        {
            //Arrange 

            //Act
            var result = _restaurantController.DeleteConfirmed(999999999);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }
         
        
        
    }
}