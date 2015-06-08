using System.Data.Entity;

namespace Miam.DataLayer.EntityFramework
{
    public class EfDropCreateIfModelChangesSeeder : DropCreateDatabaseIfModelChanges<MiamDbContext>
    {
        protected override void Seed(MiamDbContext dbContext)
        {

        }

    }


}
