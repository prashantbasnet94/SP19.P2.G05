using AutoMapper;

namespace SP19.P05.Web.Features.Menus
{
    public class MenuMapping : Profile
    {
        public MenuMapping()
        {
            CreateMap<Menu, MenuDto>()
                .ReverseMap()
                .ForMember(x => x.Id, o => o.Ignore()); // don't allow Id's to be assigned by DTOs
        }
    }
}