using System.Linq;
using Miam.DataLayer;
using Miam.Domain;
using Miam.Domain.Entities;

namespace Miam.Web.Services
{
    public class LoginService : ILoginService
    {
        readonly private IEntityRepository<User> _userRepository;

        public LoginService(IEntityRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User ValidateUser(string email, string password)
        {
            // À compléter. Ne vérifie que si le email est dans la BD !
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Email == email);
            return user;
        }
    }
}