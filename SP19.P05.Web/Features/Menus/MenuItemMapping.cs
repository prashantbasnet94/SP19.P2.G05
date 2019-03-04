using AutoMapper;
using SP19.P05.Web.Features.LineItems;

namespace SP19.P05.Web.Features.Menus
{
    public class MenuItemMapping : Profile
    {
        public MenuItemMapping()
        {
            CreateMap<MenuItem, MenuItemDto>()
                .ReverseMap()
                .ForMember(x => x.Id, o => o.Ignore()); // don't allow Id's to be assigned by DTOs
        }
    }
}