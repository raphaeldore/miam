using Externalization;
using FluentValidation;

namespace Miam.Web.ViewModels.Account
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(UiText.Login.EMPTY_PASSWORD);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(UiText.Login.EMPTY_EMAIL)
                .EmailAddress().WithMessage(UiText.Login.INVALID_EMAIL);
        }
    }
}