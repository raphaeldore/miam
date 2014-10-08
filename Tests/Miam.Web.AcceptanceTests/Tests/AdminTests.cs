using FluentAssertions;
using Miam.Domain.Entities;
using Miam.TestUtility.Database;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.PageObjects.RestaurantPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.Web.AcceptanceTests
{
    [TestClass]
    public class AdminTests : MiamAcceptanceBaseClassTests
    {
        [TestInitialize]
        public void initialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.ApplicationUserAdmin);
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
             //arrange
             var restaurant = _fixture.Create<Restaurant>();
            
             //action
             HomePage.StoreRestaurtantCount();
             CreateRestaurantPage.GoTo();
             CreateRestaurantPage.CreateRestaurant(restaurant);
           
             //Assert
             Assert.AreEqual(HomePage.PreviousRestaurantCount + 1, HomePage.CurrentRestaurantCount);
             Assert.IsTrue(HomePage.DoesRestaurantNameExist(restaurant.Name), "Le nom du restaurant ne se trouve pas dans la page.");
         }
    }
}
