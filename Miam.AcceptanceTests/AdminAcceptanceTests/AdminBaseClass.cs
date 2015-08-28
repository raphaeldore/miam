using FluentAssertions;
using Miam.AcceptanceTests;
using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.Domain.Entities;
using Miam.TestUtility.Seed;

namespace Miam.Web.AcceptanceTests.AdminAcceptanceTests
{
    public class AdminBaseClass : AcceptanceTestsBaseClass
    {
        protected ApplicationUser _userAdmin;
        protected Restaurant _restaurant1;

        protected void un_administrateur_authentifé()
        {
            _userAdmin = TestData.ApplicationUserAdmin;
            _testHelperApi.User.CreateUser(_userAdmin);

            Host.Instance.NavigateToInitialPage<HomePage>()
                .NavigationMenu
                .GotoLoginPage()
                .LoginAs(_userAdmin.Email, _userAdmin.Password);
        }
        protected void un_restaurant_existe_dans_le_système()
        {
            _restaurant1 = TestData.Restaurant1;
            _testHelperApi.Restaurants.Create(_restaurant1);
        }

        protected void AssertRestaurantsShouldBeEquivalent(Restaurant expectedRestaurant, Restaurant obtainedRestaurant)
        {
            expectedRestaurant.Name.ShouldBeEquivalentTo(obtainedRestaurant.Name);
            expectedRestaurant.City.ShouldBeEquivalentTo(obtainedRestaurant.City);
            expectedRestaurant.Country.ShouldBeEquivalentTo(obtainedRestaurant.Country);
        }

        protected void AssertContactDetailsShouldBeEquivalent(RestaurantContactDetail contactDetailsesExpected, RestaurantContactDetail contactDetailsesObtained)
        {
            contactDetailsesExpected.FaxPhone.ShouldBeEquivalentTo(contactDetailsesObtained.FaxPhone);
            contactDetailsesExpected.OfficePhone.ShouldBeEquivalentTo(contactDetailsesObtained.OfficePhone);
            contactDetailsesExpected.TwitterAlias.ShouldBeEquivalentTo(contactDetailsesObtained.TwitterAlias);
            contactDetailsesExpected.Facebook.ShouldBeEquivalentTo(contactDetailsesObtained.Facebook);
            contactDetailsesExpected.WebPage.ShouldBeEquivalentTo(contactDetailsesObtained.WebPage);
        }
    }
}
