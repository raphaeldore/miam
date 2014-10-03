using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Web.ModelBinding;
using FluentAssertions;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.Web.UnitTests.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miam.Web.Services;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.Services
{
    
    [TestClass]
    public class ValidationUserServiceTests : AllControllersBaseClassTests
    {
        private IEntityRepository<ApplicationUser> _userRepository;
        private LoginService _loginService;

        [TestInitialize]
        public void test_initialize()
        {
            _userRepository = Substitute.For<IEntityRepository<ApplicationUser>>();
            _loginService = new LoginService(_userRepository);
        }

        [TestMethod]
        public void validate_should_return_a_user_when_email_and_password_are_valid()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var user = _loginService.ValidateUser(users.First().Email, users.First().Password);

            user.First().ShouldBeEquivalentTo(users.First());
        }

        [TestMethod]
        public void validate_should_return_empty_list_when_password_is_not_valid()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var user = _loginService.ValidateUser(users.First().Email, "INVALID PASSWORD");

            user.Should().BeEmpty();
        }

        [TestMethod]
        public void validate_should_return_empty_list_when_email_is_not_valid()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var user = _loginService.ValidateUser("INVALID EMAIL", users.First().Password );

            user.Should().BeEmpty();
        }

        
    }
}
