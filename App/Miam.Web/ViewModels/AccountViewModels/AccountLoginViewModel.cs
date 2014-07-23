using System.ComponentModel.DataAnnotations;

namespace Miam.Web.ViewModels.Account
{
    public class AccountLoginViewModel
    {
        
        [Required(ErrorMessage = "Le champ courriel est requis")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Le champ mot de passe est requis")]
        public string Password { get; set; }

    }
}