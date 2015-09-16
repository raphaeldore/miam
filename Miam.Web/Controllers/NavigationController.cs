using System.Web.Mvc;
using Miam.Domain.Application;

namespace Miam.Web.Controllers
{
    public partial class NavigationController : Controller
    {
        //Todo: tests unitaires manquants
        
        [ChildActionOnly]

        public virtual ActionResult NavigationMenu()
        {
            if (User.IsInRole(Role.Admin))
            {
                return PartialView("_NavigationMenuAdmin");
            }

            if (User.IsInRole(Role.Writer))
            {
                return PartialView("_NavigationMenuWriter");
            }

            return PartialView("_NavigationMenuPublic");
        }

        [ChildActionOnly]
        public virtual ActionResult LoginPanel()
        {
            if (Request.IsAuthenticated)
            {
                return PartialView("_LoginPanelAuthentificatedUser");
            }

            return PartialView("_LoginPanelNotConnectedUser");
        }
    }
}
