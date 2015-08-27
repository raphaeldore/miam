using Miam.TestUtility.AutoFixture;
using Ploeh.AutoFixture;

namespace Miam.TestUtility.TestsAPI
{
    public class BaseTestHelper
    {
        protected Fixture Fixture;
        public BaseTestHelper()
        {
            Fixture = new Fixture();
            Fixture.Customizations.Add(new VirtualMembersOmitter());   
        }
    }
}