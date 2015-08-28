
using AutoMapper;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Home;
using Miam.Web.ViewModels.Restaurant;
using Miam.Web.ViewModels.Review;


namespace Miam.Web.Mappers
{
    public class MappersReviewToViewModel : Profile
    {
        protected override void Configure()
        {

            //Mapper.CreateMap<Review, ViewModels.Review.Create>()
            //   .ForMember(dest => dest.Restaurants, opt => opt.Ignore());

            // même résultat que la ligne ci-dessus. IgnoreAllNonExisting fait partie de la classe MappingExpressionExtensions
            Mapper.CreateMap<Review, ReviewCreateViewModel>().IgnoreAllNonExisting();

            Mapper.CreateMap<Review, ReviewIndexViewModel>();
        }
    }
}