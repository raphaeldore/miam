using System.Linq;
using System.Web.Mvc;
using Miam.DataLayer;
using Miam.Domain.Application;
using Miam.Domain.Entities;
using Miam.Web.Controllers;

namespace Miam.Web.Services
{
    public class AccountService : IAccountService
    {
        private IEntityRepository<ApplicationUser> _userRepository;

        public AccountService(IEntityRepository<ApplicationUser> userRepository)
        {
            _userRepository = userRepository;
        }
        public MayBe<ApplicationUser> ValidateUser(string email, string password)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                return new MayBe<ApplicationUser>();
            }
            if (user.Password != password)
            {
                return new MayBe<ApplicationUser>();
            }

            return new MayBe<ApplicationUser>(user);
        }

        public string HashPassword(string password)
        {
            throw new System.NotImplementedException();
        }

        public bool UserEmailExist(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}