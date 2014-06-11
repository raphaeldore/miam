using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Account;
using Miam.Web.ViewModels.AdminViewModels;
using Miam.Web.ViewModels.RestaurantViewModel;

namespace Miam.Web.Mappers
{
    class ViewModelToEntityMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToModelMappings"; }
        }

        protected override void Configure()
        {
            // Create ViewModel mapping
            Mapper.CreateMap<RestaurantCreateViewModel, Restaurant>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RestaurantId))
                .ForMember(dest => dest.Reviews, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore());

            // Edit ViewModel mapping
            Mapper.CreateMap<List<ReviewViewModel>, ICollection<Review>>();
            Mapper.CreateMap<ReviewViewModel, Review>().IgnoreAllUnmapped();
            Mapper.CreateMap<RestaurantConactDetailViewModel, RestaurantContactDetail>()
                .ForMember(dest => dest.RestaurantId, opt => opt.Ignore())
                .ForMember(dest => dest.Restaurant, opt => opt.Ignore());
            Mapper.CreateMap<AdminRestaurantEditViewModel, Restaurant>()
                .ForMember(dest => dest.Reviews, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore());

        }
    }
}