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
    public class AccountControllerLoginTests : AllControllersBaseClassTests
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
    }
}
