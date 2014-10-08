using Miam.Web.Automation;
using Miam.Web.Automation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miam.TestUtility.Database;

namespace Miam.Web.AcceptanceTests
{
    [TestClass]
    public class LoginTests : MiamAcceptanceBaseClassTests
    {
        [TestInitialize]
        public void initialize()
        {
            LoginPage.GoTo();
        }
        
        [TestMethod]
        public void admin_can_log_in()
        {
            LoginPage.LoginAs(TestData.ApplicationUserAdmin);
            Assert.IsTrue(HomePage.IsAdminLogged, "L'administrateur n'est pas connecté.");
        }

        [TestMethod]
        public void writer_can_log_in()
        {
            LoginPage.LoginAs(TestData.Writer1);
            Assert.IsTrue(HomePage.IsWriterLogged, "L'utilisateur n'est pas connecté.");
        }

    }
}
