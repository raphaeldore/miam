using Miam.Domain.Application;
using Miam.Domain.Entities;

namespace Miam.Web.Services
{
    public interface ILoginService
    {
        MayBe<ApplicationUser> ValidateUser(string email, string password);

        string HashPassword(string password);

        bool UserEmailExist(string email);
    }
}