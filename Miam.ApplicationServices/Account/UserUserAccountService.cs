using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Miam.DataLayer;
using Miam.Domain.Application;
using Miam.Domain.Entities;

namespace Miam.ApplicationsServices.Account
{
    public class UserUserAccountService : IUserAccountService
    {
        private IEntityRepository<ApplicationUser> _userRepository;

        public UserUserAccountService(IEntityRepository<ApplicationUser> userRepository)
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
            SHA256 sha256 = SHA256.Create();

            // On calcule le hash
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password)); 

            // Finalement on convertit le tout en hexadecimal
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        public bool UserEmailExist(string email)
        {
            throw new NotImplementedException();
        }
    }
}