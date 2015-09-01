using System.Linq;
using FluentAssertions;
using Miam.ApplicationsServices.Account;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.TestUtility;
using Miam.TestUtility.AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Miam.ApplicationServices.UnitTests
{
    
    [TestClass]
    public class ValidationUserServiceFixtures
    {
        private IEntityRepository<MiamUser> _userRepository;
        private UserUserAccountService _accountService;
        private Fixture _fixture;

        [TestInitialize]
        public void test_initialize()
        {
            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            _userRepository = Substitute.For<IEntityRepository<MiamUser>>();
            _accountService = new UserUserAccountService(_userRepository);
        }

        [TestMethod]
        public void validate_should_return_a_user_when_email_and_password_are_valid()
        {
            var users = _fixture.CreateMany<MiamUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var user = _accountService.ValidateUser(users.First().Email, users.First().Password);

            user.First().ShouldBeEquivalentTo(users.First());
        }

        [TestMethod]
        public void validate_should_return_empty_list_when_password_is_not_valid()
        {
            var users = _fixture.CreateMany<MiamUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

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
