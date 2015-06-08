using Miam.Domain.Application;
using Miam.Domain.Entities;

namespace Miam.Web.Services
{
    public interface IAccountService
    {
        MayBe<ApplicationUser> ValidateUser(string email, string password);

        string HashPassword(string password);

        bool UserEmailExist(string email);
    }
}