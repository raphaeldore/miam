using FluentValidation;

namespace Miam.Web.ViewModels.Review
{
    public class ReviewCreateViewModelValidator: AbstractValidator<ReviewCreateViewModel>
    {
        //Todo : Externaliser les messages
        public ReviewCreateViewModelValidator()
        {
            RuleFor(x => x.Rating)
                .NotNull().WithMessage("Le champ évaluation est requis")
                .InclusiveBetween(1, 5).WithMessage("Le champ évaluation doit être compris entre 1 et 5");

            RuleFor(x => x.Body)
                .NotEmpty().WithMessage("Le champ critique est requis")
                .Length(1,1024).WithMessage("Le champ critique doit contenir moins de 1024 caractères");

            RuleFor(x => x.RestaurantId)
                .NotEmpty().WithMessage("Le champ restaurant est requis");
        }
    }
}