using System.Data.Entity;
using Miam.DataLayer;

namespace Miam.DataLayer
{
    public interface IScopeContext
    {
        MiamDbContext GetContext();
    }

    public class ScopeContext : IScopeContext
    {
        private MiamDbContext _dbContext;

        public ScopeContext()
        {
            _dbContext = new MiamDbContext();
        }
        public MiamDbContext GetContext()
        {
            
                return _dbContext;
        }
    }
}

