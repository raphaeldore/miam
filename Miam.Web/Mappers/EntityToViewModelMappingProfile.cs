
using AutoMapper;
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
            //   .ForMember(dest => dest.Restaurant, opt => opt.Ignore());

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