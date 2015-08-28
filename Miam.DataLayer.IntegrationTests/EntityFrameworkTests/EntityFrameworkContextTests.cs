using System.Data.Entity;
using System.Linq;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;
using Miam.TestUtility.Seed;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Miam.DataLayer.IntegrationTests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkContextTests
    {
        private static EfApplicationDatabaseHelper _dataBaseHelper;
        private SeedDataBase _seedDataBase;

        [TestInitialize]
        public void TestInitialize()
        {
            _dataBaseHelper = new EfApplicationDatabaseHelper(new ApplicationContext());
            
            _dataBaseHelper.MigrateDatabaseToLatestVersion();
            _dataBaseHelper.ClearAllTables();

            _seedDataBase = new SeedDataBase(new ApplicationContext());
            _seedDataBase.SeedTables();
        }

        [TestMethod]
        public void add_restaurant_using_EFContext()
        {
            //Arrange
            const string RESTAURANT_NAME = "Le lapin grillé";
            var restaurantToAdd = new Restaurant()
                                 {
                                     City = "Quebec",
                                     Name = RESTAURANT_NAME,
                                     Country = "Canada"
                                 };

            //Action
            using (var context = new MiamDbContext())
            {
                context.Restaurants.Add(restaurantToAdd);
                context.SaveChanges();
            }

            //Assert 
            using (var context = new MiamDbContext())
            {
                var restaurantInDatabase = context.Restaurants.FirstOrDefault(x => x.Name == RESTAURANT_NAME);
                Assert.IsNotNull(restaurantInDatabase);
            }
        }

        [TestMethod]
        public void remove_restaurant_using_EFContext()
        {
            //Arrange
            Restaurant restaurantToRemove;
            using (var context = new MiamDbContext())
            {
                restaurantToRemove = context.Restaurants.First(r => r.Name == TestData.Restaurant1.Name);
            }

            //Action
            using (var context = new MiamDbContext())
            {
                context.Restaurants.Attach(restaurantToRemove);
                context.Restaurants.Remove(restaurantToRemove);
                context.SaveChanges();
            }

            //Assert 
            using (var context = new MiamDbContext())
            {
                var restaurantAfter = context.Restaurants.FirstOrDefault(r => r.Name == TestData.Restaurant1.Name);
                Assert.IsNull(restaurantAfter);
            }
        }

        [TestMethod]
        public void update_restaurant_using_EFContext()
        {
            //Arrange 
            const string NEW_RESTAURANT_NAME = "Le cochon choqué";
            Restaurant restaurantToUpdate;

            using (var context = new MiamDbContext())
            {
                restaurantToUpdate = context.Restaurants.First(r => r.Name == TestData.Restaurant1.Name);
            }

            //Action
            using (var context = new MiamDbContext())
            {
                restaurantToUpdate.Name = NEW_RESTAURANT_NAME;
                context.Restaurants.Attach(restaurantToUpdate);
                context.Entry(restaurantToUpdate).State = EntityState.Modified;
                context.SaveChanges();
            }

            //Assert 
            using (var context = new MiamDbContext())
            {
                var restaurantAfter = context.Restaurants.First(r => r.Name == NEW_RESTAURANT_NAME);
                Assert.IsNotNull(restaurantAfter);
            }
        }

        [TestMethod]
        public void update_restaurant_by_adding_review_using_EFContext()
        {
            //Arrange 
            int reviewsCountBefore;
            Restaurant restaurantToUpdate;
            Writer writer;

            using (var context = new MiamDbContext())
            {
                restaurantToUpdate = context.Restaurants.First(r => r.Name == TestData.Restaurant1.Name);
                reviewsCountBefore = restaurantToUpdate.Reviews.Count();
                writer = context.Writers.First();
            }

            var newReview = new Review()
                            {
                                Body = "Ambiance décontractée. Service trop familier.",
                                Rating = 3,
                                Writer = writer
                            };

            //Action
            using (var context = new MiamDbContext())
            {

                context.Restaurants.Attach(restaurantToUpdate);
                restaurantToUpdate.Reviews.Add(newReview);
                context.Entry(restaurantToUpdate).State = EntityState.Modified;
                context.SaveChanges();
            }

            //Assert 
            using (var context = new MiamDbContext())
            {
                var restaurantAfter = context.Restaurants.First(r => r.Name == TestData.Restaurant1.Name);
                var reviewsCountAfter = restaurantAfter.Reviews.Count();
                Assert.AreEqual(reviewsCountBefore + 1, reviewsCountAfter);
            }
        }

        
        [TestMethod]
        public void remove_restaurant_using_EFContext_should_delete_restaurantContactDetail()
        {
            //Arrange
            Restaurant restaurantToRemove;
            int contactDetailsCountBefore;
            using (var context = new MiamDbContext())
            {
                restaurantToRemove = context.Restaurants.First(r => r.Name == TestData.Restaurant1.Name);
                contactDetailsCountBefore = context.RestaurantContactDetails.Count(c => c.RestaurantId == restaurantToRemove.Id);

            }

            //Action

            using (var context = new MiamDbContext())
            {
                context.Restaurants.Attach(restaurantToRemove);
                context.Restaurants.Remove(restaurantToRemove);
                context.SaveChanges();
            }

            //Assert
            using (var context = new MiamDbContext())
            {
                var contactDetailsCountAfter = context.RestaurantContactDetails.Count(c => c.RestaurantId == restaurantToRemove.Id);
                Assert.AreEqual(contactDetailsCountBefore - 1, contactDetailsCountAfter);
            }
        }
    }
}
