using System.Data.Entity.Infrastructure;
using Miam.DataLayer;
using Miam.Domain.Entities;

namespace Miam.TestUtility.TestsHelperAPI
{
    public class UserTestHelper : BaseTestHelper
    {
        private readonly IDbContextFactory<MiamDbContext> _dbContextFactory;

        public UserTestHelper(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public void Add(MiamUser miamUserAdmin)
        {
            var dbContext = _dbContextFactory.Create();
            dbContext.MiamUsers.Add(miamUserAdmin);
            dbContext.SaveChanges();
        }
    }
}