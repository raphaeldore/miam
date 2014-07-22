using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Account;
using Miam.Web.ViewModels.RestaurantViewModel;
using Miam.Web.ViewModels.ReviewViewModels;

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
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.RestaurantId))
                .ForMember(dest => dest.Reviews, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore());

            Mapper.CreateMap<ReviewCreateViewModel, Review>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Restaurant, opt => opt.Ignore())
                .ForMember(dest => dest.Writer, opt => opt.Ignore())
                .ForMember(dest => dest.WriterId, opt => opt.Ignore());

            // Edit ViewModel mapping
            Mapper.CreateMap<List<ReviewIndexViewModel>, ICollection<Review>>();
            Mapper.CreateMap<ReviewIndexViewModel, Review>().IgnoreAllUnmapped();
            
            Mapper.CreateMap<RestaurantContactDetailViewModel, RestaurantContactDetail>()
                .ForMember(dest => dest.RestaurantId, opt => opt.Ignore())
                .ForMember(dest => dest.Restaurant, opt => opt.Ignore());
            
            Mapper.CreateMap<RestaurantEditViewModel, Restaurant>()
                .ForMember(dest => dest.Reviews, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore());

        }
    }
}