
using AutoMapper;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Home;
using Miam.Web.ViewModels.Restaurant;
using Miam.Web.ViewModels.Review;


namespace Miam.Web.Mappers
{
    public class MappersHomeToViewModel : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Restaurant, HomeIndexViewModel>()
                  .ForMember(dest => dest.RatingReviewsAverage, 
                             opt => opt.MapFrom(src => src.CalculateReviewsRatingAverage()));
        }
    }
}