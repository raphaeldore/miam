//using System.Security.Claims;
//using System.Web;
//using Miam.Domain.Entities;
//using Microsoft.AspNet.Identity;
//using Microsoft.Owin.Security;

//namespace Miam.Web.Services
//{
//    public class AuthentificationService
//    {
//        //private AccountController _accountController;

//        private readonly IAuthenticationManager _authenticationOwinContext;
//        public AuthentificationService(IAuthenticationManager authenticationOwinContext)
//        {
//            _authenticationOwinContext = authenticationOwinContext;
//        }
        

//        public void AuthentificateUser(ApplicationUser user)
//        {
//            var identity = new ClaimsIdentity(new[]
//            {
//                new Claim(ClaimTypes.NameIdentifier, user.Email),
//            },
//               DefaultAuthenticationTypes.ApplicationCookie,
//               ClaimTypes.NameIdentifier, ClaimTypes.Role);

//            foreach (var role in user.Roles)
//            {
//                identity.AddClaim(new Claim(ClaimTypes.Role, role.RoleName));
//            }

//            _authenticationOwinContext.SignIn(new AuthenticationProperties(), identity);
//        }

//        public void SignOut()
//        {
//            _authenticationOwinContext.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
//        }
//    }
//}