using Miam.Web.Automation;
using Miam.Web.Automation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miam.TestUtility.Database;

namespace Miam.Web.AcceptanceTests
{
    [TestClass]
    public class LoginTests : MiamAcceptanceTests
    {
        [TestInitialize]
        public void initialize()
        {
            LoginPage.GoTo();
        }
        
        [TestMethod]
        public void admin_can_log_in()
        {
            LoginPage.LoginAs(TestData.ApplicationUserAdmin.Email)
                     .WithPassowrd(TestData.ApplicationUserAdmin.Password)
                     .Login();
            Assert.IsTrue(HomePage.IsAdminLogged, "L'administrateur n'est pas connecté.");
        }

        [TestMethod]
        public void writer_can_log_in()
        {
            LoginPage.LoginAs(TestData.Writer1.Email)
                     .WithPassowrd(TestData.Writer1.Password)
                     .Login();
            Assert.IsTrue(HomePage.IsWriterLogged, "L'utilisateur n'est pas connecté.");
        }

    }
}
