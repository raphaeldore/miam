using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;

namespace Miam.Web.Automation.AcceptanceTestApi
{
    public class UserAcceptanceTestsAPI
    {
        private static EfDatabaseHelper _dataBaseHelper;
        private IEntityRepository<ApplicationUser> _userRepository;

        public UserAcceptanceTestsAPI()
        {
            _userRepository = new EfEntityRepository<ApplicationUser>();
        }
        public void createUser(ApplicationUser applicationUserAdmin)
        {
            _userRepository.Add(applicationUserAdmin);
        }

        public void ClearDataBaseForAcceptanceTests()
        {
            _dataBaseHelper = new EfDatabaseHelper();
            _dataBaseHelper.MigrateDatabaseToLatestVersion();
            _dataBaseHelper.ClearAllTables();
        }
    }
}