using System.Data.Entity;
using System.Linq;
using Miam.Domain.Entities;
using Miam.TestUtility.AutoFixture;
using Ploeh.AutoFixture;

namespace Miam.DataLayer.IntegrationTests.GenericRepositoryTests
{
    public class IntegrationTestHelper
    {
        private MiamDbContext contextBoundObject;
        private Fixture _fixture;

        public IntegrationTestHelper()
        {
            contextBoundObject = new MiamDbContext();

            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());
        }

        public int GetRestaurantCount()
        {
            using (var miamDbContext = new MiamDbContext())
            {
                return miamDbContext.Restaurants.Count();
            }
        }

        public Restaurant CreateAndAddRestaurantToDatabase()
        {
            var restaurant = _fixture.Create<Restaurant>();
            using (var miamDbContext = new MiamDbContext())
            {
                miamDbContext.Restaurants.Attach(restaurant);
                miamDbContext.Restaurants.Add(restaurant);
                miamDbContext.SaveChanges();
                
                return restaurant;
            }
        }

        public Restaurant GetRestaurant(Restaurant restaurant)
        {
            using (var miamDbContext = new MiamDbContext())
            {
                return miamDbContext.Restaurants.FirstOrDefault(x => x.Id == restaurant.Id);
            }
        }

        public Writer CreateAndAddWriterToDatabase()
        {
            var writer = _fixture.Create<Writer>();

            using (var miamDbContext = new MiamDbContext())
            {
                miamDbContext.Writers.Attach(writer);
                miamDbContext.Writers.Add(writer);
                miamDbContext.SaveChanges();

                return writer;
            }
        }

        public int GetReviewsCount(Restaurant restaurant)
        {
            using (var miamDbContext = new MiamDbContext())
            {
                var resto = miamDbContext.Restaurants.FirstOrDefault(x => x.Id == restaurant.Id);
                return resto.Reviews.Count();
                
            }
        }
    }
}