using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;

namespace Miam.AcceptanceTests.Automation.AcceptanceTestApi
{
    public class DatabaseHelperAcceptanceTestApi
    {
        private EfDatabaseHelper _dataBaseHelper;

        public DatabaseHelperAcceptanceTestApi()
        {
            _dataBaseHelper = new EfDatabaseHelper();
        }
        public void ClearDataBaseTables()
        {
            _dataBaseHelper = new EfDatabaseHelper();
            _dataBaseHelper.MigrateDatabaseToLatestVersion();
            _dataBaseHelper.ClearAllTables();
        }
    }
}