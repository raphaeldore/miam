using Miam.TestUtility.AutoFixture;
using Miam.Web.Automation.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.Web.AcceptanceTests
{
    [TestClass]
    public class MiamAcceptanceBaseClassTests
    {
        protected Fixture _fixture;

        [TestInitialize]
        public void Init()
        {

            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            Driver.Initialize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
