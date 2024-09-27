using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Application.Mappings
{
    /// <summary>
    /// Profile for AutoMapper configurations.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<OwnerDto, Owner>().ReverseMap();
            CreateMap<PropertyDto, Property>().ReverseMap();
            CreateMap<UpdatePropertyDto, Property>().ReverseMap();
            CreateMap<PropertyImageDto, PropertyImage>().ReverseMap();
            CreateMap<PropertyTraceDto, PropertyTrace>().ReverseMap();
        }
    }
}