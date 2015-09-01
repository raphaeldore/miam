using System.Data.Entity.Infrastructure;
using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;

namespace Miam.TestUtility.DbTestsHelperAPI
{
    public class DatabaseDataHelper
    {
        private readonly EfApplicationDatabaseHelper _applicationDatabaseHelper;

        public DatabaseDataHelper(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            var dbContext = dbContextFactory.Create();
            _applicationDatabaseHelper = new EfApplicationDatabaseHelper(dbContext);
        }
        public void ClearDataBaseTables()
        {
            _applicationDatabaseHelper.MigrateDatabaseToLatestVersion();
            _applicationDatabaseHelper.ClearAllTables();
        }
    }
}