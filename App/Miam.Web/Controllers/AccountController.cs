using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Miam.Domain.Entities;
using Miam.Web.Services;
using Miam.Web.ViewModels.Account;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;


namespace Miam.Web.Controllers
{
    public partial class AccountController : Controller
    {
        private ILoginService _loginService;

        private IAuthenticationManager AuthenticationOwinContext
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
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

            var user = _loginService.ValidateUser(accountLoginViewModel.Email, accountLoginViewModel.Password);
            if (user == null)
            {
                ModelState.AddModelError("loginError", "Email ou mot de passe invalide");
                return View("");
            }

            AuthentificateUser(user);
            return RedirectToAction(MVC.Home.Index());
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

        public virtual ActionResult Logout()
        {
            AuthenticationOwinContext.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction(MVC.Account.Login());
        }

    }

}

