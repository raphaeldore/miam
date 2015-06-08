using Miam.TestUtility.AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.TestUtility
{

    public class TestUtilities
    {
        protected Fixture _fixture;

        [TestInitialize]
        public void TestInit()
        {
            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());
        }
    }
}