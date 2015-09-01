using System;
using System.Linq;
using Miam.DataLayer;
using Miam.Domain.Application;
using Miam.Domain.Entities;

namespace Miam.ApplicationsServices.Account
{
    public class UserUserAccountService : IUserAccountService
    {
        private IEntityRepository<MiamUser> _userRepository;

        public UserUserAccountService(IEntityRepository<MiamUser> userRepository)
        {
            _userRepository = userRepository;
        }
        public MayBe<MiamUser> ValidateUser(string email, string password)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                return new MayBe<MiamUser>();
            }
            if (user.Password != password)
            {
                return new MayBe<MiamUser>();
            }

            return new MayBe<MiamUser>(user);
        }

        public string HashPassword(string password)
        {
            throw new NotImplementedException();
        }

        public bool UserEmailExist(string email)
        {
            throw new NotImplementedException();
        }
    }
}