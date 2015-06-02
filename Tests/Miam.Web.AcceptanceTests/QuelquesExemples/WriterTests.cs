//using Miam.Domain.Entities;
//using Miam.TestUtility.Database;
//using Miam.Web.Automation;
//using Miam.Web.Automation.PageObjects;
//using Miam.Web.Automation.PageObjects.ReviewPages;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Ploeh.AutoFixture;

//namespace Miam.Web.AcceptanceTests
//{
//    [TestClass]
//    public class WriterTests : MiamAcceptanceBaseClassTests
//    {
//        [Ignore]
//        [TestMethod]
        
//        public void writer_can_add_a_review()
//        {
//            //arrange
//            var review = _fixture.Create<Review>();

//            //action
//            LoginPage.GoTo();
//            LoginPage.LoginAs(TestData.Writer1);

//            CreateReviewPage.GoTo();
//            CreateReviewPage.CreateReviewForFirstRestaurant(review);


//            //assert
//            //Todo: À compléter: Vérifier si la critique a été joutée. Une fois le test complété, enlever l'attribut ignore

//        }
//    }
//}

 
