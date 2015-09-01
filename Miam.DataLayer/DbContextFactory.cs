using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miam.DataLayer
{
    public class DbContextFactory : IDbContextFactory<MiamDbContext>
    {
        public MiamDbContext Create()
        {
            return new MiamDbContext();
        }
    }
}
