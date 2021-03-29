using AutoMapper;
using Guide.Domain.Domain;
using Guide.Entity.Entity;

namespace Guide.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<int, int>();
            CreateMap<int, int>();
        }
    }
}
