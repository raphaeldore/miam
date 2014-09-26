using System.Data.Entity;

namespace Miam.DataLayer.EntityFramework
{
    public class EfDropCreateDatabaseAlwaysSeeder : DropCreateDatabaseAlways<MiamDbContext>
    {
        protected override void Seed(MiamDbContext dbContext)
        {

        }

    }


}
