using Externalization;
using FluentValidation;

namespace Miam.Web.ViewModels.Restaurant
{
    public class RestaurantCreateViewModelValidator : AbstractValidator<RestaurantCreateViewModel>
    {
        public RestaurantCreateViewModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
               .NotEmpty().WithMessage(UiText.Restaurant.NAME_REQUIRED);

            RuleFor(x => x.City)
                .NotEmpty().WithMessage(UiText.Restaurant.CITY_REQUIRED);

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage(UiText.Restaurant.COUNTRY_REQUIRED);
        }
    }
}