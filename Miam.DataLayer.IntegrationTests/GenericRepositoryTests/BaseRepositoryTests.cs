using Miam.TestUtility;
using Miam.TestUtility.AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.DataLayer.IntegrationTests.GenericRepositoryTests
{
    public class BaseRepositoryTests
    {
        protected Fixture Fixture;
        protected TestHelperApi DbTestHelper;

        [TestInitialize]
        public void BaseTestInitialize()
        {
            DbTestHelper = new TestHelperApi(new DbContextFactory());
            DbTestHelper.DataBase.ClearDataBaseTables();

            Fixture = new Fixture();
            Fixture.Customizations.Add(new VirtualMembersOmitter());
        }
    }
}