using Miam.Domain.Entities;

namespace Miam.Web.Services
{
    public interface ILoginService
    {
        User ValidateUser(string email, string password);
      
    }
}