using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using Miam.ApplicationsServices.Account;
using Miam.Domain.Entities;
using Miam.Web.Services;
using Miam.Web.ViewModels.Account;
using Microsoft.AspNet.Identity;

namespace Miam.Web.Controllers
{
    public partial class AccountController : Controller
    {
        private IHttpContextService _httpContext;
        private IAccountService _accountService;

        public AccountController(IHttpContextService httpContext,
                                 IAccountService accountService)
        {
            if (httpContext == null) throw new NullReferenceException();
            if (accountService == null) throw new NullReferenceException();

            _httpContext = httpContext;
            _accountService = accountService;
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

            var user = _accountService.ValidateUser(accountLoginViewModel.Email, accountLoginViewModel.Password);

            if (!user.Any())
            {
                ModelState.AddModelError("loginError", "Utilisateur ou mot de passe inexistant");
                return View("");
            }
            
            AuthentificateUser(user.First());

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

