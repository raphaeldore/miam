using System.Data.Entity;
using System.Data.SqlClient;
using Miam.DataLayer.Migrations;

namespace Miam.DataLayer.EntityFramework
{
    public class EfDatabaseHelper : IDatabaseHelper
    {

        
        public void DropCreateDatabaseIfModelChanges()
        {
            SqlConnection.ClearAllPools();

            var initializer = new DropCreateDatabaseIfModelChanges<MiamDbContext>();

            // Pour mettre des données dans la BD, utiliser 
            //var initializer = new EfDropCreateIfModelChangesSeeder();
            Database.SetInitializer(initializer); 
            
        }

        public void DropCreateDatabaseAlways()
        {
            SqlConnection.ClearAllPools();

            var initializer = new DropCreateDatabaseAlways<MiamDbContext>();

            // Pour mettre des données dans la BD, utiliser 
            //var initializer = new EfDropCreateDatabaseAlwaysSeeder();
            Database.SetInitializer(initializer); 
            
        }

        public void MigrateDatabaseToLatestVersion()
        {
            var initializer = new MigrateDatabaseToLatestVersion<MiamDbContext,Configuration>();
            Database.SetInitializer(initializer); 
        }

        public void CreatedatabaseIfNotExists()
        {
            SqlConnection.ClearAllPools();

            var initializer = new CreateDatabaseIfNotExists<MiamDbContext>();

            Database.SetInitializer(initializer); 
        }


        public void ClearAllTables()
        {

            var context = new MiamDbContext();

            context.Writers.RemoveRange(context.Writers);
            context.Restaurants.RemoveRange(context.Restaurants);
            context.Reviews.RemoveRange(context.Reviews);
            context.RestaurantTags.RemoveRange(context.RestaurantTags);
            context.Users.RemoveRange(context.Users);
            context.Roles.RemoveRange(context.Roles);
            context.SaveChanges();


             //Autre méthode pour tout effacer: supprimer la BD et la recréer, mais est plus lent.
            //SqlConnection.ClearAllPools();
            //context.Database.Initialize(false);
            //context.Database.Delete();
            //context.Database.CreateIfNotExists();
            //context.SaveChanges();
        }
    }
}

