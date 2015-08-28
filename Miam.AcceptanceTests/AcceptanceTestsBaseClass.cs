using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.DataLayer;
using Miam.TestUtility;
using Miam.TestUtility.TestsAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Miam.AcceptanceTests
{
    [TestClass]
    [DeploymentItem("Miam.ConnectionStrings.Local.config")]
    [DeploymentItem("Miam.ConnectionStrings.Test.config")]
    public class AcceptanceTestsBaseClass
    {
        protected TestHelperApi _testHelperApi;


        [TestInitialize]
        public void Initialize()
        {
            _testHelperApi = new TestHelperApi(new DbContextFactory());
            _testHelperApi.DataBase.ClearDataBaseTables();

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
