using System;
using System.Linq;
using FluentAssertions;
using Miam.ApplicationServices.Account;
using Miam.ApplicationServices.Security;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.TestUtility.AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Miam.ApplicationServices.UnitTests.Account
{
    
    [TestClass]
    public class ValidationUserServiceFixtures
    {
        private IEntityRepository<MiamUser> _userRepository;
        private UserUserAccountService _accountService;
        private Fixture _fixture;
        private IHashService _hashService;

        [TestInitialize]
        public void test_initialize()
        {
            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            _userRepository = Substitute.For<IEntityRepository<MiamUser>>();
            _hashService = Substitute.For<IHashService>();
            _accountService = new UserUserAccountService(_userRepository, _hashService);
        }

        [TestMethod]
        public void validate_should_return_a_user_when_email_and_password_are_valid()
        {
            var users = _fixture.CreateMany<MiamUser>(1).AsQueryable();
            _userRepository.GetAll().Returns(users);
            _hashService.VerifyPassword(Arg.Any<String>(), Arg.Any<String>()).Returns(true);

            var user = _accountService.ValidateUser(users.First().Email, users.First().Password);

            user.First().ShouldBeEquivalentTo(users.First());
        }

        [TestMethod]
        public void validate_should_return_empty_list_when_password_is_not_valid()
        {
            var users = _fixture.CreateMany<MiamUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);
            _hashService.VerifyPassword(Arg.Any<String>(), Arg.Any<String>()).Returns(false);

            var user = _accountService.ValidateUser(users.First().Email, "INVALID PASSWORD");

            user.Should().BeEmpty();
        }

        [TestMethod]
        public void validate_should_return_empty_list_when_email_is_not_valid()
        {
            var users = _fixture.CreateMany<MiamUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var user = _accountService.ValidateUser("INVALID EMAIL", users.First().Password );

            user.Should().BeEmpty();
        }

        
    }
}
