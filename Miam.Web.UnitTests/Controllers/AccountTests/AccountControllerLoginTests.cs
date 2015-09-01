using System.Security.Claims;
using System.Web.Mvc;
using FluentAssertions;
using Miam.ApplicationsServices.Account;
using Miam.Domain.Application;
using Miam.Domain.Entities;
using Miam.TestUtility;
using Miam.TestUtility.AutoFixture;
using Miam.Web.Controllers;
using Miam.Web.Services;
using Miam.Web.ViewModels.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.Controllers.AccountTests
{
    [TestClass]
    public class AccountControllerLoginTests
    {
        private AccountController _accountController;
        private IHttpContextService _httpContext;
        private IUserAccountService _userAccountService;
        private Fixture _fixture;

        [TestInitialize]
        public void AccountControllerTestInit()
        {
            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());


            _httpContext = Substitute.For<IHttpContextService>();
            _userAccountService = Substitute.For<IUserAccountService>();
            _accountController = new AccountController(_httpContext, _userAccountService);
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

        [TestMethod]
        public void login_post_should_render_default_view_when_user_is_not_valid()
         {
             //Arrange
             var loginViewModel = _fixture.Create<LoginViewModel>();
             var invalidUser = new MayBe<MiamUser>();
             _userAccountService.ValidateUser(loginViewModel.Email, loginViewModel.Password).Returns(invalidUser);

             //Action    
             var result = _accountController.Login(loginViewModel) as ViewResult;
             var viewName = result.ViewName;

             //Assert
             viewName.Should().Be("");
         }


        [TestMethod]
        public void login_should_redirect_to_home_index_when_user_is_valid()
        {
            //Arrange
            var user = _fixture.Create<MiamUser>();
            var loginViewModel = new LoginViewModel()
            {
                Email = user.Email,
                Password = user.Password
            };

            var valideUser = new MayBe<MiamUser>(user);
            _userAccountService.ValidateUser(loginViewModel.Email, loginViewModel.Password).Returns(valideUser);

            //Action    
            var routeResult = _accountController.Login(loginViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            //Assert
            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);

        }
        [TestMethod]
        public void login_should_authentificate_user_when_user_is_valid()
        {      
            //Arrange
            var user = _fixture.Create<MiamUser>();
            var loginViewModel = new LoginViewModel()
                                 {
                                    Email = user.Email,
                                    Password = user.Password
                                 };
            
            var valideUser = new MayBe<MiamUser>(user);
            _userAccountService.ValidateUser(loginViewModel.Email, loginViewModel.Password).Returns(valideUser);

            //Action    
            _accountController.Login(loginViewModel);
            

            //Assert
            _httpContext.Received().AuthenticationSignIn(Arg.Any<ClaimsIdentity>());
        
        }
    }
}
