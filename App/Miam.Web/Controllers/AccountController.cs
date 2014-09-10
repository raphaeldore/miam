using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Account;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;


namespace Miam.Web.Controllers
{
    public partial class AccountController : Controller
    {
        private IEntityRepository<ApplicationUser> _userRepository;

        private IAuthenticationManager AuthenticationOwinContext
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        public AccountController(IEntityRepository<ApplicationUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public virtual ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Login(Login accountLoginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("");
            }
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Email == accountLoginViewModel.Email);
            if (user == null)
            {
                ModelState.AddModelError("loginError", "Utilisateur inexistant");
                return View("");
            }
            if (user.Password != accountLoginViewModel.Password)
            {
                ModelState.AddModelError("loginError", "Le mot de passe est invalide");
                return View("");
            }

            AuthentificateUser(user);

            return RedirectToAction(MVC.Home.Index());
        }
        public virtual ActionResult Logout()
        {
            AuthenticationOwinContext.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction(MVC.Account.Login());
        }
        private void AuthentificateUser(ApplicationUser applicationUser)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, applicationUser.Email),
                new Claim(ClaimTypes.NameIdentifier, applicationUser.Id.ToString()),
            },
                DefaultAuthenticationTypes.ApplicationCookie);

            foreach (var role in applicationUser.Roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role.RoleName));
            }

            AuthenticationOwinContext.SignIn(new AuthenticationProperties(), identity);
        }
    }
}

