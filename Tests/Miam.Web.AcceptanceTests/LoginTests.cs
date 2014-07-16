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
        public void Admin_Can_Log_In()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.UserAdmin.Email)
                     .WithPassowrd(TestData.UserAdmin.Password)
                     .Login();

            Assert.IsTrue(HomePage.IsAdminLogged);
        }

        [TestMethod]
        public void User_Can_Log_In()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Writer1.Email)
                     .WithPassowrd(TestData.Writer1.Password)
                     .Login();
            Assert.IsTrue(HomePage.IsUserLogged);
        }

        [TestCleanup]
        public void Cleanup ()
        {
            Driver.Close();
        }
    }
}
