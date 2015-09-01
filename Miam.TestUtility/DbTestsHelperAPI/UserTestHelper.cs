using System.Data.Entity.Infrastructure;
using Miam.DataLayer;
using Miam.Domain.Entities;

namespace Miam.TestUtility.DbTestsHelperAPI
{
    public class UserTestHelper : BaseTestHelper
    {
        private readonly IDbContextFactory<MiamDbContext> _dbContextFactory;

        public UserTestHelper(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public void Add(ApplicationUser applicationUserAdmin)
        {
            var dbContext = _dbContextFactory.Create();
            dbContext.Users.Add(applicationUserAdmin);
            dbContext.SaveChanges();
        }
    }
}