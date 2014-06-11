using System.ComponentModel.DataAnnotations;

namespace Miam.Web.ViewModels.Account
{
    public class AccountLoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}