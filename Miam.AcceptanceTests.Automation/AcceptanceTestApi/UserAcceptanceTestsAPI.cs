using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;
using Miam.TestUtility.Database;

namespace Miam.AcceptanceTests.Automation.AcceptanceTestApi
{
    public class UserAcceptanceTestsApi
    {
        private IEntityRepository<ApplicationUser> _userRepository;

        public UserAcceptanceTestsApi()
        {
            _userRepository = new EfEntityRepository<ApplicationUser>();
        }
        public void createUser(ApplicationUser applicationUserAdmin)
        {
            _userRepository.Add(applicationUserAdmin);
        }
    }
}