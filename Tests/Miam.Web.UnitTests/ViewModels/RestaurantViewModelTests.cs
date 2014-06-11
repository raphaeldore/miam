// Non nécessaire, mais démontre la testabilité de viewmodel.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Miam.TestUtility.AutoFixture;
using Miam.Web.ViewModels.RestaurantViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.ViewModels
{
    [TestClass]
    public class RestaurantViewModelTests
    {
        private Fixture _fixture;
        private RestaurantCreateViewModel _restaurantCreateRestaurantViewModel;
        private ValidationContext _validationContext;
        private List<ValidationResult> _validationResults;

        [TestInitialize]
        public void testInitialize()
        {
            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            _restaurantCreateRestaurantViewModel = _fixture.Create<RestaurantCreateViewModel>();
            _validationContext = new ValidationContext(_restaurantCreateRestaurantViewModel, null, null);
            _validationResults = new List<ValidationResult>();
        }

        [TestMethod]
        public void restaurant_city_is_required()
        {
            // arrange
            _restaurantCreateRestaurantViewModel.City = "";

            // act
            Validator.TryValidateObject(_restaurantCreateRestaurantViewModel, _validationContext, _validationResults, true);

            // Assert
            Assert.IsTrue(_validationResults.Count == 1);
        }
    }
}
