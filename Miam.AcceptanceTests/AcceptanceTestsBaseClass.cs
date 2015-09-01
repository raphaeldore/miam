using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.DataLayer;
using Miam.TestUtility;
using Miam.TestUtility.DbTestsHelperAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Miam.AcceptanceTests
{
    [TestClass]
    [DeploymentItem("Miam.ConnectionStrings.Local.config")]
    [DeploymentItem("Miam.ConnectionStrings.Test.config")]
    public class AcceptanceTestsBaseClass
    {
        protected DbTestHelper DbTestHelper;


        [TestInitialize]
        public void Initialize()
        {
            DbTestHelper = new DbTestHelper(new DbContextFactory());
            DbTestHelper.DatabaseDataHelper.ClearDataBaseTables();

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
