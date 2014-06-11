//using System.Data.Entity;
//using System.Data.Entity.Validation;
//using System.Linq;
//using Miam.DataLayer.Repository;
//using Miam.Domain.Models;
//using Miam.TestUtility.AutoFixture;
//using Miam.TestUtility.Database;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Ploeh.AutoFixture;

//namespace Miam.DataLayer.IntegrationTests.DomainModelValidationTests
//{
//    [TestClass]
//    public class RestaurantValidationTests
//    {
//        private Fixture _fixture;
//        private static IUnitOfWork _unitOfWork;
//        private DataBaseTestHelper _testData;

//        [ClassInitialize]
//        public static void ClassInit(TestContext context)
//        {
//            var dbInitializer = new EfDatabaseInitializer();
//            dbInitializer.CreateDatabaseAlways();
//            _unitOfWork = new EfUnitOfWork();
//        }

//        [TestInitialize]
//        public void TestInitialize()
//        {
//            //_unitOfWork = new EntityRepository();

//            _fixture = new Fixture();
//            _fixture.Customizations.Add(new VirtualMembersOmitter());

//            _testData = new DataBaseTestHelper();
//            _testData.CleanAllTables();
//        }

//        [TestMethod]
//        [ExpectedException(typeof(DbEntityValidationException))]
//        public void add_restaurant_with_no_name_should_throw_excpetion()
//        {
//            //Arrange
//            var restaurant = _fixture.Create<Restaurant>();
//            restaurant.Name = "";

//            //Action
//            _unitOfWork.RestaurantRepository.Add(restaurant);
            

//            //Assert -  Expects exception
//        }

//        [TestMethod]
//        [ExpectedException(typeof(DbEntityValidationException))]
//        public void add_restaurant_with_more_than_three_tags_should_throw_exception()
//        {
//            //Arrange
//            var tags = _fixture.CreateMany<Tag>(4);
//            foreach (var tag in tags)
//            {
//                _unitOfWork.TagRepository.Add(tag);
//            }

//            var restaurant = _fixture.Create<Restaurant>();
//            restaurant.Tags = tags.ToList();

//            //Action
//            _unitOfWork.RestaurantRepository.Add(restaurant);

//            //Assert - Expects exception
//        }

//        [TestMethod]
//        [ExpectedException(typeof(DbEntityValidationException))]
//        public void add_restaurant_with_already_used_name_should_throw_exception()
//        {
//            //Arrange
//            const string NAME = "La poule à coco";

//            var restaurants = _fixture.CreateMany<Restaurant>(2);
//            restaurants.ElementAt(0).Name = NAME;
//            restaurants.ElementAt(1).Name = NAME;

//            _unitOfWork.RestaurantRepository.Add(restaurants.ElementAt(0));

//            //Action
//            _unitOfWork.RestaurantRepository.Add(restaurants.ElementAt(1));

//            //Assert - Expects exception
//        }
//    }
//}
