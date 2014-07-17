using System;
using Miam.Web.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miam.TestUtility.Database;

namespace Miam.Web.AcceptanceTests
{
    [TestClass]
    public class LoginTests 
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void admin_can_log_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.UserAdmin.Email).WithPassowrd(TestData.UserAdmin.Password).Login();

            Assert.IsTrue(HomePage.IsAdminLogged, "L'administrateur n'est pas connecté.");
        }

        [TestMethod]
        public void writer_can_log_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Writer1.Email).WithPassowrd(TestData.Writer1.Password).Login();

            Assert.IsTrue(HomePage.IsUserLogged, "L'utilisateur n'est pas connecté.");
        }

        [TestCleanup]
        public void Cleanup ()
        {
            Driver.Close();
        }
    }
}
