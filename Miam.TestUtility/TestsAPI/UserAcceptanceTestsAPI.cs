using System.Data.Entity.Infrastructure;
using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;

namespace Miam.TestUtility.TestsAPI
{
    public class UserAcceptanceTestsApi : BaseTestHelper
    {
        private IEntityRepository<ApplicationUser> _userRepository;

        public UserAcceptanceTestsApi(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            //_userRepository = new EfEntityRepository<ApplicationUser>(applicationContext);
        }
        public void CreateUser(ApplicationUser applicationUserAdmin)
        {
            //_userRepository.Add(applicationUserAdmin);
        }
    }
}