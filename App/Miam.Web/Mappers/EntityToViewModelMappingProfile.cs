using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using AutoMapper;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.AdminViewModels;
using Miam.Web.ViewModels.HomeViewModels;
using Miam.Web.ViewModels.RestaurantViewModel;

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
            ToUSerRestaurantViewModels();
            ToAdminRestaurantViewModels();
        }

        private void ToAdminRestaurantViewModels()
        {
            //Edit viewModel mapping
            Mapper.CreateMap<ICollection<Review>, IList<ReviewViewModel>>();
            Mapper.CreateMap<Review, ReviewViewModel>();
            Mapper.CreateMap<RestaurantContactDetail, RestaurantConactDetailViewModel>();
            Mapper.CreateMap<Restaurant, AdminRestaurantEditViewModel>();

            //Index viewModel mapping
            Mapper.CreateMap<Restaurant, AdminRestaurantIndexViewModel>()
                .ForMember(dest => dest.RatingReviewsAverage, opt => opt.MapFrom(src => src.CalculateReviewsRatingAverage()))
                .ForMember(dest => dest.CountOfReviews, opt => opt.MapFrom(src => src.Reviews.Count));

            //Delete viewModel mapping
            Mapper.CreateMap<Restaurant, AdminRestaurantDeleteViewModel>();
        }

        private static void ToUSerRestaurantViewModels()
        {
            Mapper.CreateMap<Restaurant, RestaurantCreateViewModel>()
                .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.Id));
        }
        
        private static void ToHomeViewModels()
        {
            Mapper.CreateMap<Restaurant, HomeIndexViewModel>()
                .ForMember(dest => dest.RatingReviewsAverage, opt => opt.MapFrom(src => src.CalculateReviewsRatingAverage()));
        }

    }
}