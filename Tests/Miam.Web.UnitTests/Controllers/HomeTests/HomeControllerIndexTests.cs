using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.Web.Controllers;
using Miam.Web.ViewModels.HomeViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.Controllers.HomeTests
{
    [TestClass]
    public class HomControllerIndexTests : ControllerBaseTestsClass
    {
        private HomeController _homeController;
        private IEntityRepository<Restaurant> _restaurantRepository;

        [TestInitialize]
        public void HomeControllerTestInit()
        {
            _restaurantRepository = Substitute.For<IEntityRepository<Restaurant>>();
            _homeController = new HomeController(_restaurantRepository);
        }

        [TestMethod]
        public void index_should_return_view_with_restaurants()
        {
            // Arrange   
            const int RESTAURANT_COUNT = 5;
            var restaurant = _fixture.Create<Restaurant>();

            var restaurants = _fixture.CreateMany<Restaurant>(RESTAURANT_COUNT);
            _restaurantRepository.GetAll().Returns(restaurants.AsQueryable());

            // Action
            var result = _homeController.Index() as ViewResult;
            var  model = result.Model as IEnumerable<HomeIndexViewModel>;
            
            // Assert avec fluent assertion
            //model.Count().Should().Be(RESTAURANT_COUNT);
            
            // Mieux, on compare tout le contenu 
            model.ShouldBeEquivalentTo(restaurants, options => options.ExcludingMissingProperties());
            
            // Assert sans fluent assertion
            //Assert.AreEqual(RESTAURANT_COUNT, model.Count());
        }
    }
}