using AutoMapper;

namespace SP19.P05.Web.Features.Tables
{
    public class TableFoodItemMapping : Profile
    {
        public TableFoodItemMapping()
        {
            CreateMap<TableFoodItem, TableFoodItemDto>()
                .ForMember(x => x.MenuItemName, o => o.MapFrom(x => x.MenuItem.Name))
                .ReverseMap()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.MenuItem, o => o.Ignore()); // don't allow Id's to be assigned by DTOs
        }
    }
}