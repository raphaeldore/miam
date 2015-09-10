using Externalization;
using FluentValidation;

namespace Miam.Web.ViewModels.Restaurant
{
    public class RestaurantEditViewModelValidator : AbstractValidator<RestaurantEditViewModel>
    {
        public RestaurantEditViewModelValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage(UiText.Restaurant.NAME_REQUIRED_ERROR);

            RuleFor(x => x.City)
                .NotEmpty().WithMessage(UiText.Restaurant.CITY_REQUIRED_ERROR);

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage(UiText.Restaurant.COUNTRY_REQUIRED_ERROR);
        }
    }
}