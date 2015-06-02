using FluentAssertions;
using Miam.Domain.Entities;
using Miam.TestUtility.Database;
using Miam.Web.Automation.AcceptanceTestApi;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.Seleno;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Miam.Web.AcceptanceTests.Admin
{
    public class AdminBaseClass
    {
        protected UserAcceptanceTestsApi _userAcceptanceTestApi;
        protected RestaurantAcceptanceTestApi _restaurantAcceptanceTestApi;
        protected DatabaseHelperAcceptanceTestApi _databaseHelperAcceptanceTestApi;
        protected HomePage _homePage;

        [TestInitialize]
        public void initialize()
        {
            _userAcceptanceTestApi = new UserAcceptanceTestsApi();
            _restaurantAcceptanceTestApi = new RestaurantAcceptanceTestApi();

            _databaseHelperAcceptanceTestApi = new DatabaseHelperAcceptanceTestApi();
            _databaseHelperAcceptanceTestApi.ClearDataBaseTables();

            _homePage = Host.Instance.NavigateToInitialPage<HomePage>();
        }

        [TestCleanup]
        public void cleanup()
        {
            _homePage.LogOut();
        }

        protected void un_administrateur_authentifé()
        {
            _userAcceptanceTestApi.createUser(TestData.ApplicationUserAdmin);
            var loginPage = _homePage.GoToLoginPage();
            loginPage.SelenoLoginAs(TestData.ApplicationUserAdmin.Email, TestData.ApplicationUserAdmin.Password);
        }
        protected void un_restaurant_existe_dans_le_système()
        {
            _restaurantAcceptanceTestApi.CreateRestaurant(TestData.Restaurant1);
        }

        protected void AssertRestaurantsShouldBeEquivalent(Restaurant expectedRestaurant, Restaurant obtainedRestaurant)
        {
            expectedRestaurant.Name.ShouldBeEquivalentTo(obtainedRestaurant.Name);
            expectedRestaurant.City.ShouldBeEquivalentTo(obtainedRestaurant.City);
            expectedRestaurant.Country.ShouldBeEquivalentTo(obtainedRestaurant.Country);
        }

        protected void AssertContactDetailsShouldBeEquivalent(RestaurantContactDetail contactDetailsExpected, RestaurantContactDetail contactDetailsObtained)
        {
            contactDetailsExpected.FaxPhone.ShouldBeEquivalentTo(contactDetailsObtained.FaxPhone);
            contactDetailsExpected.OfficePhone.ShouldBeEquivalentTo(contactDetailsObtained.OfficePhone);
            contactDetailsExpected.TwitterAlias.ShouldBeEquivalentTo(contactDetailsObtained.TwitterAlias);
            contactDetailsExpected.Facebook.ShouldBeEquivalentTo(contactDetailsObtained.Facebook);
            contactDetailsExpected.WebPage.ShouldBeEquivalentTo(contactDetailsObtained.WebPage);
        }
    }
}
