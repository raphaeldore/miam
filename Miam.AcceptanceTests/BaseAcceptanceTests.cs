using System;
using System.Diagnostics;
using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.TestUtility;
using Miam.TestUtility.TestsHelperAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Miam.AcceptanceTests
{
    [TestClass]
    [DeploymentItem("ConnectionStrings.config")]
    public class BaseAcceptanceTests
    {
        protected TestHelperAPI TestHelperApi;


        [TestInitialize]
        public void Initialize()
        {
            var database = new EfApplicationDatabase(new MiamDbContext());
            database.ClearAllTables();

            TestHelperApi = new TestHelperAPI();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Host.Instance.NavigateToInitialPage<HomePage>()
                .LoginPanel
                .ForceLogout();
        }
    }
}
