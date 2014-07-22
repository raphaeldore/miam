using System.Web;
using Microsoft.AspNet.Identity;

namespace Miam.Web.Services
{
    class HttpContextService : IHttpContextService
    {
        public int GetUserId()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();

            return int.Parse(userId);
        }
    }
}