using Miam.TestUtility.AutoFixture;
using Miam.Web.Automation.AcceptanceTestApi;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.Seleno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.Web.AcceptanceTests
{
    [TestClass]
    public class AcceptanceTestsBaseClass
    {

        protected UserAcceptanceTestsApi _userAcceptanceTestApi;
        protected RestaurantAcceptanceTestApi _restaurantAcceptanceTestApi;
        protected DatabaseHelperAcceptanceTestApi _databaseHelperAcceptanceTestApi;
      

        [TestInitialize]
        public void initialize()
        {
            _userAcceptanceTestApi = new UserAcceptanceTestsApi();
            _restaurantAcceptanceTestApi = new RestaurantAcceptanceTestApi();

            _databaseHelperAcceptanceTestApi = new DatabaseHelperAcceptanceTestApi();
            _databaseHelperAcceptanceTestApi.ClearDataBaseTables();
        }

        [TestCleanup]
        public void cleanup()
        {
            Host.Instance.NavigateToInitialPage<HomePage>()
                .LoginPanel
                .ForceLogout();
        }
    }
}
