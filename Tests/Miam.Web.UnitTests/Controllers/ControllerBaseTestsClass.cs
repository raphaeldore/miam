using Miam.TestUtility.AutoFixture;
using Miam.Web.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.Controllers
{

    public class ControllerBaseTestsClass
    {
        protected Fixture _fixture;

        [TestInitialize]
        public void ControllerTestInit()
        {

            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            AutoMapperConfiguration.Configure();

        }
    }
}