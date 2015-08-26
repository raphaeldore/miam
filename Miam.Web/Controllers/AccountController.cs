using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using AutoMapper;
using Miam.ApplicationsServices.Account;
using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Application;
using Miam.Domain.Entities;
using Miam.Web.Services;
using Miam.Web.ViewModels.Account;
using Microsoft.AspNet.Identity;

namespace Miam.Web.Controllers
{
    public partial class AccountController : Controller
    {
        private readonly IHttpContextService _httpContext;
        private readonly IUserAccountService _userAccountService;
        private readonly IEntityRepository<ApplicationUser> _applicationUserRepository; // = new EfEntityRepository<ApplicationUser>();

        public AccountController(IHttpContextService httpContext,
                                 IUserAccountService userAccountService,
                                 IEntityRepository<ApplicationUser> applicationUserRepository )
        {
            if (httpContext == null ||
                userAccountService == null ||
                applicationUserRepository == null) throw new NullReferenceException();

            _httpContext = httpContext;
            _userAccountService = userAccountService;
            _applicationUserRepository = applicationUserRepository;
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
                return View();
            }

            var user = _userAccountService.ValidateUser(accountLoginViewModel.Email, accountLoginViewModel.Password);

            if (!user.Any())
            {
                ModelState.AddModelError("loginError", "Utilisateur ou mot de passe inexistant");
                return View();
            }
            
            AuthentificateUser(user.First());

            return RedirectToAction(MVC.Home.Index());
        }

        [HttpGet]
        public ActionResult Edit()
        {
            // _applicationUserRepository = new EfEntityRepository<ApplicationUser>();

            ApplicationUser applicationUser = _applicationUserRepository.GetById(_httpContext.GetUserId());

            if (applicationUser != null)
            {
                var accountEditPageViewModel = Mapper.Map<Edit>(applicationUser);

                return View(accountEditPageViewModel);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Edit editAccountViewModel)
        {
            if (!ModelState.IsValid)
                return View(editAccountViewModel);

            var applicationUser = _applicationUserRepository.GetById(editAccountViewModel.Id);

            if (applicationUser == null)
                return HttpNotFound();

            if (applicationUser.Password == _userAccountService.HashPassword(editAccountViewModel.CurrentPassword))
            {
                editAccountViewModel.NewPassword = _userAccountService.HashPassword(editAccountViewModel.NewPassword);

                Mapper.Map(editAccountViewModel, applicationUser);

                _applicationUserRepository.Update(applicationUser);

                return RedirectToAction(MVC.Home.Index());
            }

            ModelState.AddModelError(string.Empty, "Le mot de passe actuel que vous avez entré n'est pas valide.");

            return View(editAccountViewModel);
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

