using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Externalization;

namespace Miam.Web.ViewModels.Account
{
    public class LoginViewModel
    {
        [DisplayName(UiText.Login.EMAIL)]
        [Required(ErrorMessage = UiText.Login.EMAIL_REQUIRED_ERROR)]
        public string Email { get; set; }

        [DisplayName(UiText.Login.PASSWORD)]
        [Required(ErrorMessage = UiText.Login.PASSWORD_REQUIRED_ERROR)]
        public string Password { get; set; }
    }
}