using AutoMapper;

namespace SP19.P05.Web.Features.Tables
{
    public class TableBillMapping : Profile
    {
        public TableBillMapping()
        {
            CreateMap<TableBill, TableBillDto>()
                .ReverseMap()
                .ForMember(x => x.Id, o => o.Ignore()); // don't allow Id's to be assigned by DTOs
        }
    }
}