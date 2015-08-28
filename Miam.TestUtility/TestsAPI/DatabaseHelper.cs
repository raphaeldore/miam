using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;

namespace Miam.TestUtility.TestsAPI
{
    public class DatabaseHelper
    {
        private readonly EfApplicationDatabaseHelper _applicationDatabaseHelper;

        public DatabaseHelper(ApplicationContext applicationContext)
        {
            _applicationDatabaseHelper = new EfApplicationDatabaseHelper(applicationContext);

        }
        public void ClearDataBaseTables()
        {
            _applicationDatabaseHelper.MigrateDatabaseToLatestVersion();
            _applicationDatabaseHelper.ClearAllTables();
        }
    }
}