using FluentAssertions;
using Miam.TestUtility.Database;
using Miam.Web.Automation;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.PageObjects.RestaurantPages;
using Miam.Web.Automation.Selenium;
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
            LoginPage.LoginAs(TestData.ApplicationUserAdmin.Email)
                     .WithPassowrd(TestData.ApplicationUserAdmin.Password)
                     .Login();
        }

        [TestMethod]
        public void admin_can_delete_restaurant()
        {
            HomePage.StoreRestaurtantCount();

            EditRestaurantPage.GoTo();
            EditRestaurantPage.DeleteFirstRestaurant();

            HomePage.GoTo();
            Assert.AreNotEqual(HomePage.PreviousRestaurantCount, HomePage.CurrentRestaurantCount);
        }

         [TestMethod]
        public void admin_can_edit_restaurant()
        {
             EditRestaurantPage.GoTo();
             EditRestaurantPage.ModifytFirstRestaurantWith(TestData.Restaurant3);
             
             //assert
             EditRestaurantPage.FirstRestaurant.ShouldBeEquivalentTo(TestData.Restaurant3);
        }

         [TestMethod]
         public void admin_can_add_a_restaurant()
         {
             const string RESTAURANT_NAME = "Lulu la patate";
             
             HomePage.StoreRestaurtantCount();

             CreateRestaurantPage.GoTo();
             CreateRestaurantPage.CreateRestaurant(RESTAURANT_NAME)
                                 .WithCity("Québec")
                                 .WithCountry("Canada")
                                 .Create();
             //Assert
             Assert.AreEqual(HomePage.PreviousRestaurantCount + 1, HomePage.CurrentRestaurantCount);
             Assert.IsTrue(HomePage.DoesRestaurantNameExist(RESTAURANT_NAME), "Le nom du restaurant ne se trouve pas dans la page.");
         }
    }
}
