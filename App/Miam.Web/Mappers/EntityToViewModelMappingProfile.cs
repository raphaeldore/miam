using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using AutoMapper;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.HomeViewModels;
using Miam.Web.ViewModels.RestaurantViewModel;
using Miam.Web.ViewModels.ReviewViewModels;

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
            
            Mapper.CreateMap<RestaurantContactDetail, RestaurantContactDetailViewModel>();

            Mapper.CreateMap<Restaurant, RestaurantEditViewModel>();
                

            //Index viewModel mapping
            Mapper.CreateMap<Restaurant, RestaurantIndexViewModel>()
                .ForMember(dest => dest.RatingReviewsAverage, opt => opt.MapFrom(src => src.CalculateReviewsRatingAverage()))
                .ForMember(dest => dest.CountOfReviews, opt => opt.MapFrom(src => src.Reviews.Count));

            //Delete viewModel mapping
            Mapper.CreateMap<Restaurant, RestaurantDeleteViewModel>();

            //Create viewModel mapping
            Mapper.CreateMap<Restaurant, RestaurantCreateViewModel>()
              .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.Id));
        }

        private static void ToReviewViewModels()
        {
            //Create viewModel mapping
            Mapper.CreateMap<Review, ReviewCreateViewModel>()
               .ForMember(dest => dest.Restaurants, opt => opt.Ignore());

            Mapper.CreateMap<Review, ReviewIndexViewModel>();

        }
        
        private static void ToHomeViewModels()
        {
            Mapper.CreateMap<Restaurant, HomeIndexViewModel>()
                .ForMember(dest => dest.RatingReviewsAverage, opt => opt.MapFrom(src => src.CalculateReviewsRatingAverage()));
        }

    }
}