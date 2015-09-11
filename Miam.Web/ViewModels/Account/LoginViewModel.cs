using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Externalization;
using FluentValidation.Attributes;

namespace Miam.Web.ViewModels.Account
{
    [Validator(typeof(LoginViewModelValidator))]
    public class LoginViewModel
    {

        [DisplayName(UiText.Login.EMAIL)]
        public string Email { get; set; }
        
        [DisplayName(UiText.Login.PASSWORD)]
        public string Password { get; set; }
    }
}