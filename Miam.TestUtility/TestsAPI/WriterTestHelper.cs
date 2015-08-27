using System.Linq;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Ploeh.AutoFixture;

namespace Miam.TestUtility.TestsAPI
{
    public class WriterTestHelper : BaseTestHelper
    {
        private MiamDbContext miamDbContext;
        

        public WriterTestHelper(ApplicationContext applicationContext)
        {
            miamDbContext = applicationContext.Context;
        }

        public Writer Create()
        {
            var writer = Fixture.Create<Writer>();

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