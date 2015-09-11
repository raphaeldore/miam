using Miam.DataLayer.EntityFramework;
using Miam.TestUtility;
using Miam.TestUtility.AutoFixture;
using Miam.TestUtility.DbTestsHelperAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.DataLayer.IntegrationTests.GenericRepositoryTests
{
    // DeploymentItem copie le fichier ConnectionStrings.config avec le DLL des tests d'integration. 
    // Fichier nécessaire lors de l'execution avec Jenkins
    // App.config, fait référence à ce fichier.
    [DeploymentItem("ConnectionStrings.config")]

    public class BaseRepositoryTests
    {
        protected Fixture Fixture;
        protected DbTestHelper DbTestHelper;

        [TestInitialize]
        public void BaseTestInitialize()
        {
            DbTestHelper = new DbTestHelper();
            
            var database = new EfApplicationDatabase(new MiamDbContext());
            database.ClearAllTables();

            Fixture = new Fixture();
            Fixture.Customizations.Add(new VirtualMembersOmitter());
        }
    }
}