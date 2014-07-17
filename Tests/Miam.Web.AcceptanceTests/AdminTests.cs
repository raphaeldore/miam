
using FluentAssertions;
using Miam.Domain.Entities;
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
        public void admin_can_delete_restaurant()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.UserAdmin.Email).WithPassowrd(TestData.UserAdmin.Password).Login();
            
            AdminPage.Goto();
            var restaurantNameToDelete = AdminPage.FirstRestaurantName;
            
            AdminPage.DeleteFirstRestaurant();

            Assert.AreNotEqual(AdminPage.FirstRestaurantName, restaurantNameToDelete);
        }

         [TestMethod]
        public void admin_can_edit_restaurant()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.UserAdmin.Email).WithPassowrd(TestData.UserAdmin.Password).Login();

            AdminPage.Goto();
            AdminPage.ModifytFirstRestaurantWith(TestData.Restaurant3);

            AdminPage.FirstRestaurant.ShouldBeEquivalentTo(TestData.Restaurant3);
        }


         [TestCleanup]
         public void Cleanup()
         {
             Driver.Close();
         }
        

    }
}
