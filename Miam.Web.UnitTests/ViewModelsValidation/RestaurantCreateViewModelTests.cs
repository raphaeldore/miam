using System.Linq;
using Externalization;
using FluentAssertions;
using Miam.Web.ViewModels.Restaurant;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.ViewModelsTests
{
    [TestClass]
    public class RestaurantCreateViewModelTests : BaseViewModelValidation

    {
        private RestaurantCreateViewModel _restaurantCreateViewModel;
        private RestaurantCreateViewModelValidator _validator;

        [TestInitialize]
        public void TestInitialize()
        {
            _restaurantCreateViewModel = _fixture.Create<RestaurantCreateViewModel>();
            _validator = new RestaurantCreateViewModelValidator();
        }

        [TestMethod]
        public void restaurant_name_is_required()
        {
            _restaurantCreateViewModel.Name = "";
            var results = _validator.Validate(_restaurantCreateViewModel);
            results.Errors.First().ErrorMessage.Should().Be(UiText.Restaurant.NAME_REQUIRED);
        }
        [TestMethod]
        public void restaurant_city_is_required()
        {
            _restaurantCreateViewModel.City = "";
            var results = _validator.Validate(_restaurantCreateViewModel);
            results.Errors.First().ErrorMessage.Should().Be(UiText.Restaurant.CITY_REQUIRED);
        }
        [TestMethod]
        public void restaurant_country_is_required()
        {
            _restaurantCreateViewModel.Country = "";
            var results = _validator.Validate(_restaurantCreateViewModel);
            results.Errors.First().ErrorMessage.Should().Be(UiText.Restaurant.COUNTRY_REQUIRED);
        }
    }
}
