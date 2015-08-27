using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;

namespace Miam.TestUtility.TestsAPI
{
    public class DatabaseHelper
    {
        private EfApplicationDatabaseHelper _applicationDatabaseHelper;

        public DatabaseHelper()
        {
            _applicationDatabaseHelper = new EfApplicationDatabaseHelper(new ApplicationContext());
        }
        public void ClearDataBaseTables()
        {
            _applicationDatabaseHelper = new EfApplicationDatabaseHelper(new ApplicationContext());
            _applicationDatabaseHelper.MigrateDatabaseToLatestVersion();
            _applicationDatabaseHelper.ClearAllTables();
        }
    }
}