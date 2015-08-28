using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.TestUtility.AutoFixture;
using Ploeh.AutoFixture;

namespace Miam.TestUtility.TestsAPI
{
    public class ReviewTestHelper : BaseTestHelper
    {
        private IDbContextFactory<MiamDbContext> _dbContextFactory;

        public ReviewTestHelper(IDbContextFactory<MiamDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        //public int Count(Restaurant restaurant)
        //{
        //    var dbContext = _dbContextFactory.Create();
        //    var resto = dbContext.Restaurants.FirstOrDefault(x => x.Id == restaurant.Id);
        //    return resto.Reviews.Count();
            
        //}

        public void Create(Review review)
        {
            var dbContext = _dbContextFactory.Create();
            dbContext.Reviews.Add(review);
            dbContext.SaveChanges();
        }

        //public void Create(Writer writer, Restaurant restaurant, string bodyReview, int i)
        //{
        //    var dbContext = _dbContextFactory.Create();
        //    dbContext.Reviews.Add(new Review()
        //    {
        //        Body = "aaa",
        //        Restaurant = restaurant,
        //        Writer = writer,
        //        Rating = i
        //    });
            
        //}
        public int Count()
        {
            var dbContext = _dbContextFactory.Create();
            return dbContext.Reviews.Count();
        }
    }
}