using System.Security.Claims;
using Microsoft.Owin.Security;

namespace Miam.Web.Services
{
    public interface IHttpContextService
    {
        int GetUserId();
        void AuthenticationSignIn(ClaimsIdentity identity);
        void AuthenticationSignOut();
    }
}