using System.Web.Mvc;
using FluentAssertions;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Miam.Web.UnitTests.Controllers.AccountTests
{
    [TestClass]
    public class AccountControllerLoginTests : ControllerBaseTestsClass
    {
        private IEntityRepository<ApplicationUser> _userRepository;
        private AccountController _accountController;

        [TestInitialize]
        public void AccountControllerTestInit()
        {

            _userRepository = Substitute.For<IEntityRepository<ApplicationUser>>();
            _accountController = new AccountController(_userRepository);
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
