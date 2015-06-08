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
//    public class WriterValidationTests
//    {
//        private Fixture _fixture;
//        private IUnitOfWork _unitOfWork;
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
//        public void add_writer_with_already_used_email_should_throw_exception()
//        {
//            //Arrange
//            const string EMAIL = "un@email.com";

//            var writers = _fixture.CreateMany<Writer>(2);
//            writers.ElementAt(0).Email = EMAIL ;
//            writers.ElementAt(1).Email = EMAIL;
//            _unitOfWork.WriterRepository.Add(writers.ElementAt(0));

//            //Action
//            _unitOfWork.WriterRepository.Add(writers.ElementAt(1));

//            //Assert - Expects exception
//        }

//        [TestMethod]
//        [ExpectedException(typeof(DbEntityValidationException))]
//        public void update_writer_with_already_used_email_should_throw_exception()
//        {
//            //Arrange
//            const string EMAIL1 = "email1@email.com";
//            const string EMAIL2 = "email2@email.com";

//            var writers = _fixture.CreateMany<Writer>(2);
//            writers.ElementAt(0).Email = EMAIL1;
//            _unitOfWork.WriterRepository.Add(writers.ElementAt(0));
            
//            writers.ElementAt(1).Email = EMAIL2;
//            _unitOfWork.WriterRepository.Add(writers.ElementAt(1));

//            //Action
//            writers.ElementAt(1).Email = EMAIL1;
//            _unitOfWork.WriterRepository.Add(writers.ElementAt(1));

//            //Assert - Expects exception
//        }



         
//    }
//}
