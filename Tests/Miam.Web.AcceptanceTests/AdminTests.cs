using FluentAssertions;
using Miam.TestUtility.Database;
using Miam.Web.Automation;
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
            LoginPage.LoginAs(TestData.UserAdmin.Email).WithPassowrd(TestData.UserAdmin.Password).Login();
        }


        [TestMethod]
        public void admin_can_delete_restaurant()
        {
            AdminPage.Goto();
            var restaurantNameToDelete = AdminPage.FirstRestaurantName;
            AdminPage.DeleteFirstRestaurant();

            Assert.AreNotEqual(AdminPage.FirstRestaurantName, restaurantNameToDelete);
        }

         [TestMethod]
        public void admin_can_edit_restaurant()
        {
            AdminPage.Goto();
            AdminPage.ModifytFirstRestaurantWith(TestData.Restaurant3);

            AdminPage.FirstRestaurant.ShouldBeEquivalentTo(TestData.Restaurant3);
        }
    }
}
