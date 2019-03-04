using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P05.Web.Data;
using SP19.P05.Web.Features.Payments;

namespace SP19.P05.Web.Controllers
{
    public class CustomerPaymentOptionsController : ApiBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public CustomerPaymentOptionsController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<CustomerPaymentOptionDto>>> Get(int customerId)
        {
            var entityQueryable = dataContext.Set<PaymentOption>().Where(x => x.CustomerId == customerId);
            var dtoQueryable = mapper.ProjectTo<CustomerPaymentOptionDto>(entityQueryable);
            var itemDtos = await dtoQueryable.ToArrayAsync();
            return itemDtos;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerPaymentOptionDto>> Post(CustomerPaymentOptionDto dto)
        {
            var entity = new PaymentOption();
            mapper.Map(dto, entity);
            dataContext.Add(entity);
            await dataContext.SaveChangesAsync();
            dto.Id = entity.Id;
            return dto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await dataContext.Set<PaymentOption>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            dataContext.Remove(entity);
            await dataContext.SaveChangesAsync();
            return Ok();
        }
    }
}