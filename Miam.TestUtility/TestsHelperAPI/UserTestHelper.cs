using System.Data.Entity.Infrastructure;
using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;

namespace Miam.TestUtility.TestsAPI
{
    public class UserTestHelper : BaseTestHelper
    {
        private readonly IDbContextFactory<MiamDbContext> _dbContextFactory;

        public UserTestHelper(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public void CreateUser(ApplicationUser applicationUserAdmin)
        {
            var dbContext = _dbContextFactory.Create();
            dbContext.Users.Add(applicationUserAdmin);
            dbContext.SaveChanges();
        }
    }
}