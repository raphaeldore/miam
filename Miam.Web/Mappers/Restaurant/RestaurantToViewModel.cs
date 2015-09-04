
using AutoMapper;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Home;
using Miam.Web.ViewModels.Restaurant;
using Miam.Web.ViewModels.Review;


namespace Miam.Web.Mappers
{
    public class MappersRestaurantToViewModel : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Restaurant, RestaurantEditViewModel>()
                .ForMember(dest => dest.ContactDetailViewModel, opt => opt.MapFrom(src => src.RestaurantContactDetail))
                .ForMember(dest => dest.ReviewsViewModel, opt => opt.MapFrom(src => src.Reviews));

            Mapper.CreateMap<Restaurant, RestaurantIndexViewModel>()
                .ForMember(dest => dest.RatingReviewsAverage, opt => opt.MapFrom(src => src.CalculateReviewsRatingAverage()))
                .ForMember(dest => dest.CountOfReviews, opt => opt.MapFrom(src => src.Reviews.Count));

            Mapper.CreateMap<Restaurant, RestaurantDeleteViewModel>();

            Mapper.CreateMap<Restaurant, RestaurantCreateViewModel>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.ContactDetailViewModel, opt => opt.MapFrom(src => src.RestaurantContactDetail));

             Mapper.CreateMap<Restaurant, HomeIndexViewModel>()
                  .ForMember(dest => dest.RatingReviewsAverage, 
                             opt => opt.MapFrom(src => src.CalculateReviewsRatingAverage()));
        }
    }
}