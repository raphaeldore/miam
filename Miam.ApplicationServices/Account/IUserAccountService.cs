using Miam.Domain.Application;
using Miam.Domain.Entities;

namespace Miam.ApplicationServices.Account
{
    public interface IUserAccountService
    {
        MayBe<MiamUser> ValidateUser(string email, string password);

        string HashPassword(string password);

        bool UserEmailExist(string email);
    }
}