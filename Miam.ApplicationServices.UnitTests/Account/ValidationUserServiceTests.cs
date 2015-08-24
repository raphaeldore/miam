using System;
using System.Linq;
using System.Text;
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
    public class ValidationUserServiceTests : TestUtilities
    {
        private IEntityRepository<ApplicationUser> _userRepository;
        private UserUserAccountService _accountService;

        [TestInitialize]
        public void test_initialize()
        {
            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            _userRepository = Substitute.For<IEntityRepository<ApplicationUser>>();
            _accountService = new UserUserAccountService(_userRepository);
        }

        [TestMethod]
        public void validate_should_return_a_user_when_email_and_password_are_valid()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var user = _accountService.ValidateUser(users.First().Email, users.First().Password);

            user.First().ShouldBeEquivalentTo(users.First());
        }

        [TestMethod]
        public void validate_should_return_empty_list_when_password_is_not_valid()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var user = _accountService.ValidateUser(users.First().Email, "INVALID PASSWORD");

            user.Should().BeEmpty();
        }

        [TestMethod]
        public void validate_should_return_empty_list_when_email_is_not_valid()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var user = _accountService.ValidateUser("INVALID EMAIL", users.First().Password );

            user.Should().BeEmpty();
        }

        [TestMethod]
        public void hash_password_should_return_the_sha256_hash_of_the_password()
        {
            var plainTextPwd = "123Soleil";
            var plainTextPwdSha256Hash = "BCCC3F25B4B70A9E4704CAB21DC772E932FF62AF32AA475F15C4903044DEC995";

            var pwdHash = _accountService.HashPassword(plainTextPwd);

            pwdHash.Should().Be(plainTextPwdSha256Hash);
        }

        [TestMethod]
        public void UserEmailExist_should_return_false_when_email_does_not_exist()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var userExists = _accountService.UserEmailExist("this_example_does_not_exist_in_the_database@example.nl");

            userExists.Should().BeFalse();
        }

        [TestMethod]
        public void UserEmailExist_should_return_true_when_email_exists()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var userExists = _accountService.UserEmailExist(users.First().Email);

            userExists.Should().BeTrue();
        }
        
    }
}
