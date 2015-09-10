using System;
using System.Linq;
using Externalization;
using FluentAssertions;
using FluentValidation.TestHelper;
using Miam.Web.UnitTests.ViewModelsTests;
using Miam.Web.ViewModels.Review;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.ViewModelsValidation
{
    [TestClass]
    public class ReviewCreateViewModelTests : BaseViewModelValidation
    {
        private ReviewCreateViewModel _reviewCreateViewModel;
        private ReviewCreateViewModelValidator _validator;

        [TestInitialize]
        public void TestInitialize()
        {
            _reviewCreateViewModel = _fixture.Build<ReviewCreateViewModel>().Without(x => x.Restaurants).Create();
            
            _validator = new ReviewCreateViewModelValidator();
        }

        [TestMethod]
        public void review_rating_is_required()
        {
            _reviewCreateViewModel = _fixture.Build<ReviewCreateViewModel>()
                                             .Without(x => x.Restaurants)
                                             .Without(x => x.Rating)
                                             .Create();
            var results = _validator.Validate(_reviewCreateViewModel);
            //Todo: externaliser le message
            results.Errors.First().ErrorMessage.Should().Be("Le champ évaluation est requis");
        }
        //Todo: compléter les tests suite à l'externalisation
      
    }
}
