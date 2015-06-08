using Miam.AcceptanceTests.Automation.AcceptanceTestApi;
using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Miam.AcceptanceTests
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
