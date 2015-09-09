using System;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using Miam.DataLayer;

namespace Miam.TestUtility.DbTestsHelperAPI
{
    public class DbTestHelper 
    {
        private IDbContextFactory<MiamDbContext> _dbContextFactory;

        public DbTestHelper()
        {
            _dbContextFactory = new DbContextFactory();
            WriteToConsoleDataBaseInformation();

        }

        public RestaurantTestHelper Restaurants
        {
            get { return new RestaurantTestHelper(_dbContextFactory); }
        }
        public ReviewTestHelper Reviews
        {
            get { return new ReviewTestHelper(_dbContextFactory); }
        }
        public UserTestHelper Users
        {
            get { return new UserTestHelper(_dbContextFactory); }
        }

        public TagTestHelper Tags
        {
            get { return new TagTestHelper(_dbContextFactory); }
        }
        private void WriteToConsoleDataBaseInformation()
        {
            var context = _dbContextFactory.Create();
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.WriteLine("Connection string: " + context.Database.Connection.ConnectionString);
            Trace.WriteLine("Datasource: " + context.Database.Connection.DataSource);
            Trace.WriteLine("Database name: " + context.Database.Connection.Database);
            Trace.WriteLine("");
        }
    }
}