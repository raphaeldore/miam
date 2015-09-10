using Miam.TestUtility.AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.ViewModelsTests
{
    public class BaseViewModelValidation
    {
        protected Fixture _fixture;
        [TestInitialize]
        public void BaseTestInitialize()
        {
            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());
        }
    }
}