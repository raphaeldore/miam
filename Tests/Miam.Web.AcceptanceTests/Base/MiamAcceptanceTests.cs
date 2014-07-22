using Miam.Web.Automation;
using Miam.Web.Automation.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Miam.Web.AcceptanceTests
{
    public class MiamAcceptanceTests
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
