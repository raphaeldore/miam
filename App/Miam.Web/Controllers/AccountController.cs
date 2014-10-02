using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.Web.Services;
using Microsoft.AspNet.Identity;


namespace Miam.Web.Controllers
{
    public partial class AccountController : Controller
    {
        private IEntityRepository<ApplicationUser> _userRepository;
        private IHttpContextService _httpContext;

        public AccountController(IEntityRepository<ApplicationUser> userRepository,
                                 IHttpContextService httpContext)
        {
            _userRepository = userRepository;
            _httpContext = httpContext;
        }

        public virtual ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Login(ViewModels.Account.Login accountLoginViewModel)
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
            _httpContext.AuthenticationSignOut();
            return RedirectToAction(Views.ViewNames.Login);
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

            _httpContext.AuthenticationSignIn(identity);
        }
    }
}

