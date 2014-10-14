using System.Data.Entity;
using System.Data.SqlClient;

namespace Miam.DataLayer.EntityFramework
{
    public class EfDatabaseHelper : IDatabaseHelper
    {

        
        public void DropCreateDatabaseIfModelChanges()
        {
            SqlConnection.ClearAllPools();

            var initializer = new DropCreateDatabaseIfModelChanges<MiamDbContext>();

            // Pour mettre des données dans la BD, utiliser 
            //var initializer = new EfDatabaseDropCreateIfModelChangesSeeder();
            Database.SetInitializer(initializer); 
            
        }

        public void DropCreateDatabaseAlways()
        {
            SqlConnection.ClearAllPools();

            var initializer = new DropCreateDatabaseAlways<MiamDbContext>();

            // Pour mettre des données dans la BD, utiliser 
            //var initializer = new EfDatabaseDropCreateIfModelChangesSeeder();
            Database.SetInitializer(initializer); 
            
        }


        public void DeleteAll()
        {
            var context = new MiamDbContext();

            //context.Database.ExecuteSqlCommand("set net_write_timeout=99999; set net_read_timeout=99999");

            context.Database.Initialize(false);
            context.Database.Delete();
            context.Database.CreateIfNotExists();
            context.SaveChanges();
        }
    }
}

