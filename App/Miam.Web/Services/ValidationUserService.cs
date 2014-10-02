using System.Linq;
using System.Web.Mvc;
using Miam.DataLayer;
using Miam.Domain.Application;
using Miam.Domain.Entities;
using Miam.Web.Controllers;

namespace Miam.Web.Services
{
    public class ValidationUserService : IValidationUserService
    {
        private IEntityRepository<ApplicationUser> _userRepository;

        public ValidationUserService(IEntityRepository<ApplicationUser> userRepository)
        {
            _userRepository = userRepository;
        }
        public MayBe<ApplicationUser> Validate(string email, string password)
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
    }
}