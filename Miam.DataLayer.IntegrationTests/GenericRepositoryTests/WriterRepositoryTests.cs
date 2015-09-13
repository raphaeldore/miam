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
            _writerRepository= new EfEntityRepository<Writer>(new MiamDbContext());

            _writer = Fixture.Create<Writer>();
            _restaurant = Fixture.Create<Restaurant>();
        }
        
        [TestMethod]
        public void remove_writer_using_generic_repository_should_cascade_delete_reviews()
        {
            //Arrange
            var review = Fixture.Build<Review>()
                                 .With(x => x.Writer, _writer)
                                 .With(x => x.Restaurant, _restaurant)
                                 .Create();
            TestHelperApi.Reviews.Add(review);   

            //Action
            var writerToDelete = _writerRepository.GetById(_writer.Id);
            _writerRepository.Delete(writerToDelete);
            
            //Assert 
            int reviewsCountAfter = TestHelperApi.Reviews.Count();
            reviewsCountAfter.Should().Be(0);
        }
    }
}
