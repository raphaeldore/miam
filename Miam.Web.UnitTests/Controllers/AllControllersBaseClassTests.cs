using Miam.TestUtility;
using Miam.TestUtility.AutoFixture;
using Miam.Web.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.Controllers
{

    public class AllControllersBaseClassTests : TestUtilities
    {
    
        [TestInitialize]
        public void ControllerTestInit()
        {
            AutoMapperConfiguration.Configure();
        }
    }
}