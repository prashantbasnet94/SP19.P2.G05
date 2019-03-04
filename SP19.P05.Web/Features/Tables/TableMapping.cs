using AutoMapper;

namespace SP19.P05.Web.Features.Tables
{
    public class TableMapping : Profile
    {
        public TableMapping()
        {
            CreateMap<Table, TableDto>()
                .ReverseMap()
                .ForMember(x => x.Id, o => o.Ignore()); // don't allow Id's to be assigned by DTOs
        }
    }
}