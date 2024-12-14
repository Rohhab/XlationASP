using AutoMapper;
using XlationASP.Dtos;
using XlationASP.Models;

namespace XlationASP.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Xlator, XlatorDto>();
            CreateMap<XlatorDto, Xlator>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
