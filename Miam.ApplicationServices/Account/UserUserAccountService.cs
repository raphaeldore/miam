using System;
using System.Linq;
using Miam.ApplicationServices.Security;
using Miam.DataLayer;
using Miam.Domain.Application;
using Miam.Domain.Entities;

namespace Miam.ApplicationServices.Account
{
    public class UserUserAccountService : IUserAccountService
    {
        private IEntityRepository<MiamUser> _userRepository;
        private IHashService _hashService;

        public UserUserAccountService(IEntityRepository<MiamUser> userRepository, IHashService hashService)
        {
            _userRepository = userRepository;
            _hashService = hashService;
        }
        public MayBe<MiamUser> ValidateUser(string email, string password)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Email == email);

            string test = _hashService.HashPassword(password);

            if (user == null)
            {
                return new MayBe<MiamUser>();
            }

            if(!_hashService.VerifyPassword(password, user.Password))
            {
                return new MayBe<MiamUser>();
            }

            return new MayBe<MiamUser>(user);
        }

        public string HashPassword(string password)
        {
            return _hashService.HashPassword(password);
        }

        public bool UserEmailExist(string email)
        {
            return _userRepository.GetAll().Any(x => x.Email == email);
        }
    }
}