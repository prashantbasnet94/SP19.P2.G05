using AutoMapper;
using SP19.P03.Web.Features.Customers;
using SP19.P03.Web.Features.Menus;
using SP19.P03.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SP19.P03.Web.Features.LineItems;
using SP19.P03.Web.Features.Authorization;
using SP19.P03.Web.Features.Tables;
using SP19.P03.Web.Features.Payments;

namespace SP19.P03.Web.Dto
{
    public class AutoMapperPorfile:Profile
    {
        public AutoMapperPorfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<PaymentOption, CustomerPaymentOptionsDto>().ReverseMap();
            CreateMap<Menu, MenuDto>().ReverseMap();
          //  CreateMap<Receipt, MenuDto>().ReverseMap();
            CreateMap<MenuItem, MenuItemDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Table, TableDto>().ReverseMap();
            CreateMap<TableBill, TableBillDto>().ReverseMap();
            CreateMap<TableFoodItem, TableFoodItemDto>().ReverseMap();

        }
    }
}
