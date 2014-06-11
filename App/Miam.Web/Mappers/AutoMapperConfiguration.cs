using AutoMapper;

namespace Miam.Web.Mappers
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
                {
                    x.AddProfile<EntityToViewModelMappingProfile>();
                    x.AddProfile<ViewModelToEntityMappingProfile>();
                });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
