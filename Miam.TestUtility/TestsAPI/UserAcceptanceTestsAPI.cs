using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;

namespace Miam.TestUtility.TestsAPI
{
    public class UserAcceptanceTestsApi : BaseTestHelper
    {
        private IEntityRepository<ApplicationUser> _userRepository;

        public UserAcceptanceTestsApi(ApplicationContext applicationContext)
        {
            _userRepository = new EfEntityRepository<ApplicationUser>(applicationContext);
        }
        public void createUser(ApplicationUser applicationUserAdmin)
        {
            _userRepository.Add(applicationUserAdmin);
        }
    }
}