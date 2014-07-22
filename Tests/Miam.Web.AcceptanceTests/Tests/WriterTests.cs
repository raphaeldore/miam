﻿using Miam.TestUtility.Database;
using Miam.Web.Automation;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.PageObjects.ReviewPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Miam.Web.AcceptanceTests
{
    [TestClass]
    public class WriterTests : MiamAcceptanceTests
    {
        [Ignore]
        [TestMethod]
        
        public void writer_can_add_a_review()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Writer1.Email).WithPassowrd(TestData.Writer1.Password).Login();

            CreateReviewPage.GoTo();
            CreateReviewPage.CreateReviewForFirstRestaurant("Ambiance froide, mais très bon chef.")
                            .WithRating(3)
                            .Create();

            //Todo: test à compléter: Vérifier si la critiques a été joutée. Une fois compléter, enlever l'attribut ignore
            
        }
    }
}

 
