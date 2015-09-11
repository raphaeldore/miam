using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using Externalization;
using Miam.ApplicationServices.Account;
using Miam.Domain.Entities;
using Miam.Web.Services;
using Miam.Web.ViewModels.Account;
using Microsoft.AspNet.Identity;

namespace Miam.Web.Controllers
{
    public partial class AccountController : Controller
    {
        private IHttpContextService _httpContext;
        private IUserAccountService _userAccountService;

        public AccountController(IHttpContextService httpContext,
                                 IUserAccountService userAccountService)
        {
            if (httpContext == null) throw new NullReferenceException();
            if (userAccountService == null) throw new NullReferenceException();

            _httpContext = httpContext;
            _userAccountService = userAccountService;
        }

        public virtual ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Login(LoginViewModel accountLoginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("");
            }

            var user = _userAccountService.ValidateUser(accountLoginViewModel.Email, accountLoginViewModel.Password);

            if (!user.Any())
            {
                ModelState.AddModelError("loginError", UiText.Login.INCORRECT_LOGIN_OR_PASSWORD);
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

        private void AuthentificateUser(MiamUser miamUser)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, miamUser.Email),
                new Claim(ClaimTypes.NameIdentifier, miamUser.Id.ToString()),
            },
                DefaultAuthenticationTypes.ApplicationCookie);

            foreach (var role in miamUser.Roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role.RoleName));
            }

            _httpContext.AuthenticationSignIn(identity);
        }
    }
}

