using System.Web.Mvc;
using FluentAssertions;
using Miam.Web.Controllers;
using Miam.Web.UnitTests.Controllers.Home;
using Miam.Web.ViewModels.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Miam.Web.Services;

namespace Miam.Web.UnitTests.Controllers.Account
{
    [TestClass]
    public class AccountControllerLoginTests : ControllerBaseTestsClass
    {
        private ILoginService _loginServiceMock;
        private AccountController _accountController;

        [TestInitialize]
        public void AccountControllerTestInit()
        {

            _loginServiceMock = Substitute.For<ILoginService>();
            _accountController = new AccountController(_loginServiceMock);
        }

         [TestMethod]
        public void login_should_render_default_view()
        {
            //Action    
            var result = _accountController.Login() as ViewResult;
            var viewName = result.ViewName;

            //Assert
            viewName.Should().Be("");
        }

         //[TestMethod]
         //public void post_create_should_add_user_to_repository_with_encrypted_password()
         //{
         //    // Arrange   
         //    var accountLoginViewModel = _fixture.Create<AccountLoginViewModel>();
         //    accountLoginViewModel.Password = "admin";

         //    // Action
         //    AuthenticationController.Create(accountLoginViewModel);

         //    // Assert (avec NSubstitute)
         //    //_repositoryMock.Received().Add(Arg.Is<Writer>(x => x.Id == us.Id));
         //    //_UnitOfWorkMock.Received().Commit();
         //}

    //todo: test page en https
    }
}
