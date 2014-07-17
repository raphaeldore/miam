using Miam.Web.Automation;
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
