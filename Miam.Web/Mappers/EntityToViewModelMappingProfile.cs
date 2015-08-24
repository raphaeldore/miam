
using System;
using AutoMapper;
using AutoMapper.Internal;
using Miam.Domain.Entities;



namespace Miam.Web.Mappers
{
    public class EntityToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "EntityToViewModelMappings"; }
        }

        protected override void Configure()
        {        
            ToHomeViewModels();
            ToReviewViewModels();
            ToRestaurantViewModels();
            ToRestaurantContactDetailViewModel();
            ToApplicationViewModels();
        }

        private void ToApplicationViewModels()
        {
            Mapper.CreateMap<ApplicationUser, ViewModels.Account.Edit>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.NewPassword, opts => opts.MapFrom(src => String.Empty))
                .ForMember(dest => dest.RepeatPassword, opts => opts.MapFrom(src => String.Empty));
        }

        private void ToRestaurantViewModels()
        {
            Mapper.CreateMap<Restaurant, ViewModels.Restaurant.Edit>();
          
            Mapper.CreateMap<Restaurant, ViewModels.Restaurant.Index>()
                .ForMember(dest => dest.RatingReviewsAverage, opt => opt.MapFrom(src => src.CalculateReviewsRatingAverage()))
                .ForMember(dest => dest.CountOfReviews, opt => opt.MapFrom(src => src.Reviews.Count));

            Mapper.CreateMap<Restaurant, ViewModels.Restaurant.Delete>();

            Mapper.CreateMap<Restaurant, ViewModels.Restaurant.Create>()
              .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.Id));
        }

        private static void ToReviewViewModels()
        {
            //Mapper.CreateMap<Review, ViewModels.Review.Create>()
            //   .ForMember(dest => dest.Restaurants, opt => opt.Ignore());

            // même résultat que la ligne ci-dessus. IgnoreAllNonExisting fait partie de la classe MappingExpressionExtensions
            Mapper.CreateMap<Review, ViewModels.Review.Create>().IgnoreAllNonExisting();

            Mapper.CreateMap<Review, ViewModels.Review.Index>();

        }
        
        private static void ToHomeViewModels()
        {
            Mapper.CreateMap<Restaurant, ViewModels.Home.Index>()
                .ForMember(dest => dest.RatingReviewsAverage, opt => opt.MapFrom(src => src.CalculateReviewsRatingAverage()));
        }

        private void ToRestaurantContactDetailViewModel()
        {
            Mapper.CreateMap<RestaurantContactDetail, ViewModels.Restaurant.ContactDetail>();
        }
    }
}