using Miam.Domain.Application;
using Miam.Domain.Entities;

namespace Miam.Web.Services
{
    public interface IValidationUserService
    {
        MayBe<ApplicationUser> Validate(string email, string password);
    }
}