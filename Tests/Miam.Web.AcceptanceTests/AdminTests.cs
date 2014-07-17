
using Miam.TestUtility.Database;
using Miam.Web.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Miam.Web.AcceptanceTests
{
    [TestClass]
    public class AdminTests
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void Admin_Can_Delete_Restaurant()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.UserAdmin.Email).WithPassowrd(TestData.UserAdmin.Password).Login();
            
            AdminPage.Goto();
            var restaurantNameToDelete = AdminPage.FirstRestaurantName;
            
            AdminPage.DeleteFirstRestaurant();

            Assert.AreNotEqual(AdminPage.FirstRestaurantName, restaurantNameToDelete);
        }


        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }

    }
}
