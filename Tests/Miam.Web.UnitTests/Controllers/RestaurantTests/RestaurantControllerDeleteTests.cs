using System.Web.Mvc;
using FluentAssertions;
using Miam.Web.ViewModels.RestaurantViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.Controllers.RestaurantTests
{
    [TestClass]
    public class RestaurantControllerDeleteTests : RestaurantControllerBaseTestsClass
    {
        [TestMethod]
        public void delete_restaurant_should_return_view_when_restaurantID_is_valid()
        {
            //Arrange 
            var restaurant = _fixture.Create<Domain.Entities.Restaurant>();
            _restaurantRepository.GetById(restaurant.Id).Returns(restaurant);

            //Action
            var result = _adminController.DeleteRestaurant(restaurant.Id) as ViewResult;
            var restaurantViewModel = result.ViewData.Model as RestaurantDeleteViewModel;

            //Assert 
            restaurantViewModel.ShouldBeEquivalentTo(restaurant); 
        }

        [TestMethod]
        public void delete_post_should_remove_restaurant()
        {
            //Arrange
            const int RESTAURANT_ID = 10;

            //Action
            _adminController.DeleteRestaurantConfirmed(RESTAURANT_ID);

            // Assert
            _restaurantRepository.Received().DeleteById(RESTAURANT_ID);
        }

        [TestMethod]
        public void delete_post_should_redirect_to_index_on_success()
        {
            //Arrange
            const int RESTAURANT_ID = 10;

            //todo: a revoir 
            //Act
            var routeResult = _adminController.DeleteRestaurantConfirmed(RESTAURANT_ID) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            //Assert
            routeAction.ShouldBeEquivalentTo(MVC.Home.Views.ViewNames.Index);

        }

        //Todo: faire les tests pour les différents scénarios de  httpnotfound de DeleteRestaurant DeleteReview DeleteRestaurantConfirmed

    }
}