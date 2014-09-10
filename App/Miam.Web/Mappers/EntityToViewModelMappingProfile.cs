
using AutoMapper;
using Miam.Domain.Entities;

using Create = Miam.Web.ViewModels;


namespace Miam.Web.Mappers
{
    public class EntityToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ModelToViewModelMappings"; }
        }

        protected override void Configure()
        {
            ToHomeViewModels();
            ToReviewViewModels();
            ToRestaurantViewModels();
        }

        private void ToRestaurantViewModels()
        {
            //Edit viewModel mapping

            Mapper.CreateMap<RestaurantContactDetail, ViewModels.Restaurant.ContactDetail>();

            Mapper.CreateMap<Restaurant, ViewModels.Restaurant.Edit>();
                

            //Index viewModel mapping
            Mapper.CreateMap<Restaurant, ViewModels.Restaurant.Index>()
                .ForMember(dest => dest.RatingReviewsAverage, opt => opt.MapFrom(src => src.CalculateReviewsRatingAverage()))
                .ForMember(dest => dest.CountOfReviews, opt => opt.MapFrom(src => src.Reviews.Count));

            //Delete viewModel mapping
            Mapper.CreateMap<Restaurant, ViewModels.Restaurant.Delete>();

            //Create viewModel mapping
            Mapper.CreateMap<Restaurant, ViewModels.Restaurant.Create>()
              .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.Id));
        }

        private static void ToReviewViewModels()
        {
            //Create viewModel mapping
            Mapper.CreateMap<Review, ViewModels.Review.Create>()
               .ForMember(dest => dest.Restaurants, opt => opt.Ignore());

            Mapper.CreateMap<Review, ViewModels.Review.Index>();

        }
        
        private static void ToHomeViewModels()
        {
            Mapper.CreateMap<Restaurant, ViewModels.Home.Index>()
                .ForMember(dest => dest.RatingReviewsAverage, opt => opt.MapFrom(src => src.CalculateReviewsRatingAverage()));
        }

    }
}