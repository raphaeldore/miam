using System.Linq;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.TestUtility.AutoFixture;
using Ploeh.AutoFixture;

namespace Miam.TestUtility.TestsAPI
{
    public class ReviewTestHelper : BaseTestHelper
    {
        private MiamDbContext miamDbContext;

        public ReviewTestHelper(ApplicationContext applicationContext)
        {
            miamDbContext = applicationContext.Context;

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