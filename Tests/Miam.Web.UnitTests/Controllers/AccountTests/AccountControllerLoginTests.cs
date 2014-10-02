using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Miam.DataLayer;
using Miam.Domain.Application;
using Miam.Domain.Entities;
using Miam.Web.Controllers;
using Miam.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.Controllers.AccountTests
{
    [TestClass]
    public class AccountControllerLoginTests : AllControllersBaseClassTests
    {
        private AccountController _accountController;
        private IHttpContextService _httpContext;
        private IValidationUserService _validationUserService;

        [TestInitialize]
        public void AccountControllerTestInit()
        {
            _httpContext = Substitute.For<IHttpContextService>();
            _validationUserService = Substitute.For<IValidationUserService>();
            _accountController = new AccountController(_httpContext, _validationUserService);
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
             var loginViewModel = _fixture.Create<ViewModels.Account.Login>();
             var invalidUser = new MayBe<ApplicationUser>();
             _validationUserService.Validate(loginViewModel.Email, loginViewModel.Password).Returns(invalidUser);

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
            var user = _fixture.Create<ApplicationUser>();
            var loginViewModel = new ViewModels.Account.Login()
            {
                Email = user.Email,
                Password = user.Password
            };

            var valideUser = new MayBe<ApplicationUser>(user);
            _validationUserService.Validate(loginViewModel.Email, loginViewModel.Password).Returns(valideUser);

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
            var user = _fixture.Create<ApplicationUser>();
            var loginViewModel = new ViewModels.Account.Login()
                                 {
                                    Email = user.Email,
                                    Password = user.Password
                                 };
            
            var valideUser = new MayBe<ApplicationUser>(user);
            _validationUserService.Validate(loginViewModel.Email, loginViewModel.Password).Returns(valideUser);

            //Action    
            _accountController.Login(loginViewModel);
            

            //Assert
            _httpContext.Received().AuthenticationSignIn(Arg.Any<ClaimsIdentity>());
        
        }
    }
}
