using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P05.Web.Data;
using SP19.P05.Web.Features.Authorization;
using SP19.P05.Web.Features.Customers;

namespace SP19.P05.Web.Controllers
{
    public class CustomersController : ApiBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public CustomersController(DataContext dataContext, IMapper mapper, UserManager<User> userManager)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> Get()
        {
            var entityQueryable = dataContext.Set<Customer>();
            var dtoQueryable = mapper.ProjectTo<CustomerDto>(entityQueryable);
            var itemDtos = await dtoQueryable.ToArrayAsync();
            return itemDtos;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> PostAsync(CreateCustomerDto dto)
        {
            using (var transaction = await dataContext.Database.BeginTransactionAsync())
            {
                var user = new User();
                mapper.Map(dto, user);
                var identityResult = await userManager.CreateAsync(user, dto.Password);
                if (!identityResult.Succeeded)
                {
                    return BadRequest(identityResult.Errors);
                }
                await userManager.AddToRoleAsync(user, UserRoles.Customer);
                var customer = new Customer
                {
                    User = user
                };
                mapper.Map(dto, customer);
                dataContext.Add(customer);
                await dataContext.SaveChangesAsync();

                var result = mapper.Map<CustomerDto>(dto);
                result.Id = customer.Id;
                transaction.Commit();
                return result;
            }
        }
    }
}
