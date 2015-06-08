using System.Security.Claims;

namespace Miam.ApplicationsServices.Http
{
    public interface IHttpContextService
    {
        int GetUserId();
        void AuthenticationSignIn(ClaimsIdentity identity);
        void AuthenticationSignOut();
    }
}