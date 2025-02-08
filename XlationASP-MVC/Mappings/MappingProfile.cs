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
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<Book, BookDto>();
            CreateMap<Genre, GenreDto>();

            CreateMap<XlatorDto, Xlator>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<BookDto, Book>()
                .ForMember(b => b.Id, opt => opt.Ignore());

            CreateMap<ApplicationUser, UserRolesDto>();
        }
    }
}
