using AutoMapper;

namespace Miam.Web.Mappers
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
                {
                    x.AddProfile<MappersContactDetailsToEntity>();
                    x.AddProfile<MappersContactDetailsToViewModel>();
                    x.AddProfile<MappersHomeToViewModel>();
                    x.AddProfile<MappersRestaurantToEntity>();
                    x.AddProfile<MappersRestaurantToViewModel>();
                    x.AddProfile<MappersReviewToEntity>();
                    x.AddProfile<MappersReviewToViewModel>();
                });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
