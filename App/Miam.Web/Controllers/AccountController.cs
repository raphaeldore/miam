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
        private IEntityRepository<User> _userRepository;

        private IAuthenticationManager AuthenticationOwinContext
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        public AccountController(IEntityRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public virtual ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Login(AccountLoginViewModel accountLoginViewModel)
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
        private void AuthentificateUser(User user)
        {
            var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Email),
                },
                DefaultAuthenticationTypes.ApplicationCookie,
                ClaimTypes.NameIdentifier, ClaimTypes.Role);

            foreach (var role in user.Roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role.RoleName));
            }

            AuthenticationOwinContext.SignIn(new AuthenticationProperties(), identity);
        }

       

    }

}

