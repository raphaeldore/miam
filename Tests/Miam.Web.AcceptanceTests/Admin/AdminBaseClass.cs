using Miam.Web.Automation.AcceptanceTestApi;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.Seleno;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Miam.Web.AcceptanceTests.Admin
{
    public class AdminBaseClass
    {
        protected UserAcceptanceTestsApi _userAcceptanceTestApi;
        protected DatabaseHelperAcceptanceTestApi _databaseHelperAcceptanceTestApi;
        protected HomePage _homePage;

        [TestInitialize]
        public void initialize()
        {
            _userAcceptanceTestApi = new UserAcceptanceTestsApi();
            _databaseHelperAcceptanceTestApi = new DatabaseHelperAcceptanceTestApi();
            _databaseHelperAcceptanceTestApi.ClearDataBaseTables();

            _homePage = Host.Instance.NavigateToInitialPage<HomePage>();
        }

        [TestCleanup]
        public void cleanup()
        {
            _homePage.LogOut();
        }
    }
}
