using FluentAssertions;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.DataLayer.IntegrationTests.GenericRepositoryTests
{

    [TestClass]
    public class WriterRepositoryTests :BaseRepositoryTests
    {
        private EfEntityRepository<Writer> _writerRepository;
        private Restaurant _restaurant;
        private Writer _writer;

        [TestInitialize]
        public void TestInitialize()
        {
            _writerRepository= new EfEntityRepository<Writer>(new ApplicationContext());

            _writer = Fixture.Create<Writer>();
            _restaurant = Fixture.Create<Restaurant>();
        }
        
        [TestMethod]
        public void remove_writer_using_generic_repository_should_cascade_delete_reviews()
        {
            //Arrange
            DbTestHelper.Writer.Create(_writer);
            DbTestHelper.Restaurants.Create(_restaurant);
            var review = Fixture.Build<Review>()
                                 .With(x => x.WriterId, _writer.Id)
                                 .With(x => x.RestaurantId, _restaurant.Id)
                                 .Create();
            DbTestHelper.Reviews.Create(review);   

            //Action
            var writerToDelete = _writerRepository.GetById(_writer.Id);
            _writerRepository.Delete(writerToDelete);
            
            //Assert 
            int reviewsCountAfter = DbTestHelper.Reviews.Count();
            reviewsCountAfter.Should().Be(0);
        }
    }
}
