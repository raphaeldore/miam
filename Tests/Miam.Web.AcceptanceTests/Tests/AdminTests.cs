using FluentAssertions;
using Miam.TestUtility.Database;
using Miam.Web.Automation;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.PageObjects.RestaurantPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Miam.Web.AcceptanceTests
{
    [TestClass]
    public class AdminTests : MiamAcceptanceTests
    {
        [TestInitialize]
        public void initialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.ApplicationUserAdmin.Email).WithPassowrd(TestData.ApplicationUserAdmin.Password).Login();
        }

        [TestMethod]
        public void admin_can_delete_restaurant()
        {
            ManageRestaurantPage.GoTo();
            var restaurantNameToDelete = ManageRestaurantPage.FirstRestaurantName;
            ManageRestaurantPage.DeleteFirstRestaurant();

            Assert.AreNotEqual(ManageRestaurantPage.FirstRestaurantName, restaurantNameToDelete);
        }

         [TestMethod]
        public void admin_can_edit_restaurant()
        {
            
             ManageRestaurantPage.GoTo();
             ManageRestaurantPage.ModifytFirstRestaurantWith(TestData.Restaurant3);
             ManageRestaurantPage.FirstRestaurant.ShouldBeEquivalentTo(TestData.Restaurant3);
        }

         [TestMethod]
         public void admin_can_add_a_restaurant()
         {
             const string RESATURANT_NAME = "Lulu la patate";

             CreateRestaurantPage.GoTo();
             CreateRestaurantPage.CreateRestaurant(RESATURANT_NAME)
                                 .WithCity("Québec")
                                 .WithCountry("Canada")
                                 .Create();

             Assert.IsTrue(HomePage.Contain(RESATURANT_NAME), "Le nom du restaurant ne se trouve pas dans la page.");
         }
    }
}
