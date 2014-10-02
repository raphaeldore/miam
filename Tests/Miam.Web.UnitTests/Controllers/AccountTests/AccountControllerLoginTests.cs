using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Miam.DataLayer;
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
        private IEntityRepository<ApplicationUser> _userRepository;
        private AccountController _accountController;
        private IHttpContextService _httpContext;

        [TestInitialize]
        public void AccountControllerTestInit()
        {

            _userRepository = Substitute.For<IEntityRepository<ApplicationUser>>();
            _httpContext = Substitute.For<IHttpContextService>();
            _accountController = new AccountController(_userRepository, _httpContext);
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
        public void login_post_should_render_default_view_when_user_email_does_not_exist()
         {
             //Arrange
             var users = _fixture.CreateMany<ApplicationUser>();
             _userRepository.GetAll().Returns(users.AsQueryable());

             var loginViewModel = _fixture.Build<ViewModels.Account.Login>()
                                          .With(x => x.Email, "EMAIL DOES NOT EXIST")
                                          .Create();
             
             //Action    
             var result = _accountController.Login(loginViewModel) as ViewResult;
             var viewName = result.ViewName;

             //Assert
             viewName.Should().Be("");
         }
         
        [TestMethod]
         public void login_should_render_default_view_when_user_password_is_not_valid()
         {
             //Arrange
             var users = _fixture.CreateMany<ApplicationUser>();
             _userRepository.GetAll().Returns(users.AsQueryable());

             var loginViewModel = _fixture.Build<ViewModels.Account.Login>()
                                          .With(x => x.Email, users.ElementAt(0).Email)
                                          .With(x => x.Password, "INVALID PASSWORD")
                                          .Create();

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
            var users = _fixture.CreateMany<ApplicationUser>();
            _userRepository.GetAll().Returns(users.AsQueryable());

            var loginViewModel = new ViewModels.Account.Login()
            {
                Email = users.ElementAt(0).Email,
                Password = users.ElementAt(0).Password
            };
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
            var users = _fixture.CreateMany<ApplicationUser>();
            _userRepository.GetAll().Returns(users.AsQueryable());

            var loginViewModel = new ViewModels.Account.Login()
            {
                Email = users.ElementAt(0).Email,
                Password = users.ElementAt(0).Password
            };
            //Action    
            _accountController.Login(loginViewModel);
            

            //Assert
            _httpContext.Received().AuthenticationSignIn(Arg.Any<ClaimsIdentity>());
        
        }
    }
}
