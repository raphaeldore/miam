
using System.Collections.Generic;
using AutoMapper;
using Miam.Domain.Entities;

namespace Miam.Web.Mappers
{
    class ViewModelToEntityMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToEntityMappings"; }
        }

        protected override void Configure()
        {
            ToRestaurant();
            ToReview();
            ToRestaurantContact();
            ToApplicationUser();
        }

        private void ToApplicationUser()
        {
            Mapper.CreateMap<ViewModels.Account.Edit, ApplicationUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(x => x.NewPassword))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
                .IgnoreAllNonExisting();
        }

        private void ToRestaurant()
        {
            //Mapper.CreateMap<ViewModels.Restaurant.Create, Restaurant>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.RestaurantId))
            //    .ForMember(dest => dest.Reviews, opt => opt.Ignore())
            //    .ForMember(dest => dest.Tags, opt => opt.Ignore());

            // même résultat que la ligne ci-dessus. IgnoreAllNonExisting fait partie de la classe MappingExpressionExtensions
            Mapper.CreateMap<ViewModels.Restaurant.Create, Restaurant>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.RestaurantId))
                .IgnoreAllNonExisting();


            Mapper.CreateMap<ViewModels.Restaurant.Edit, Restaurant>()
                .ForMember(dest => dest.Reviews, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore());
        }
        private void ToRestaurantContact()
        {
            Mapper.CreateMap<ViewModels.Restaurant.ContactDetail, RestaurantContactDetail>()
                .ForMember(dest => dest.RestaurantId, opt => opt.Ignore())
                .ForMember(dest => dest.Restaurant, opt => opt.Ignore());
        }

        private void ToReview()
        {
            Mapper.CreateMap<ViewModels.Review.Create, Review>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Restaurant, opt => opt.Ignore())
               .ForMember(dest => dest.Writer, opt => opt.Ignore())
               .ForMember(dest => dest.WriterId, opt => opt.Ignore());
        }

      
    }
}