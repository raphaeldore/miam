using System;
using System.Data.Entity;
using Miam.DataLayer;

namespace Miam.DataLayer
{
    public class ApplicationContext : IDisposable
    {
        private readonly MiamDbContext _dbContext;

        public ApplicationContext()
        {
            _dbContext = new MiamDbContext();
        }


        public MiamDbContext Context
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

