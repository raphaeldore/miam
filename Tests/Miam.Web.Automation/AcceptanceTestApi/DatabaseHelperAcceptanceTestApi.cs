using Miam.DataLayer.EntityFramework;

namespace Miam.Web.Automation.AcceptanceTestApi
{
    public class DatabaseHelperAcceptanceTestApi
    {
        private EfDatabaseHelper _dataBaseHelper;

        public DatabaseHelperAcceptanceTestApi()
        {
            _dataBaseHelper = new EfDatabaseHelper();
        }
        public void ClearDataBaseForAcceptanceTests()
        {
            _dataBaseHelper = new EfDatabaseHelper();
            _dataBaseHelper.MigrateDatabaseToLatestVersion();
            _dataBaseHelper.ClearAllTables();
        }
    }
}