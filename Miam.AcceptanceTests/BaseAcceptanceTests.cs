using System;
using System.Diagnostics;
using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.TestUtility;
using Miam.TestUtility.DbTestsHelperAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Miam.AcceptanceTests
{
    [TestClass]
    [DeploymentItem("ConnectionStrings.config")]
    public class BaseAcceptanceTests
    {
        protected DbTestHelper DbTestHelper;


        [TestInitialize]
        public void Initialize()
        {
            var database = new EfApplicationDatabase(new MiamDbContext());
            database.ClearAllTables();

            DbTestHelper = new DbTestHelper();
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
