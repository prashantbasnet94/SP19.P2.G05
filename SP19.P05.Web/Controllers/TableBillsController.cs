using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SP19.P05.Web.Data;
using SP19.P05.Web.Features.Customers;
using SP19.P05.Web.Features.Tables;
using SP19.P05.Web.Hubs;

namespace SP19.P05.Web.Controllers
{
    public class TableBillsController : ApiBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IHubContext<NotificationHub> hubContext;

        public TableBillsController(DataContext dataContext, IMapper mapper, IHubContext<NotificationHub> hubContext)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.hubContext = hubContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableBillDto>>> Get()
        {
            var entityQueryable = dataContext.Set<TableBill>();
            var dtoQueryable = mapper.ProjectTo<TableBillDto>(entityQueryable);
            var itemDtos = await dtoQueryable.ToArrayAsync();
            return itemDtos;
        }

        [HttpPost("{tableBillId}/addCustomer/{customerId}")]
        public async Task<ActionResult<TableBillDto>> AddCustomerToTableBill(int tableBillId, int customerId)
        {
            if (!await dataContext.Set<Customer>().AnyAsync(x => x.Id == customerId))
            {
                return NotFound();
            }
            var userId = await dataContext.Set<Customer>()
                .Where(x => x.Id == customerId)
                .Select(x => x.UserId)
                .FirstOrDefaultAsync();
            var entityQueryable = dataContext.Set<TableBill>()
                .Where(x => x.Id == tableBillId);
            var dtoQueryable = mapper.ProjectTo<TableBillDto>(entityQueryable);
            var dto = await dtoQueryable.FirstOrDefaultAsync();
            if (dto == null)
            {
                return NotFound();
            }

            if (await dataContext.Set<CustomerTableBill>().AnyAsync(x => x.CustomerId == customerId && x.TableBillId == tableBillId))
            {
                // note: this is a race condition and you should probably use RFC 7807
                return BadRequest("duplicate record");
            }
            dataContext.Add(new CustomerTableBill
            {
                CustomerId = customerId,
                TableBillId = tableBillId
            });
            await dataContext.SaveChangesAsync();
            await hubContext.Clients.User(userId.ToString()).SendAsync("addedToBill");

            return dto;
        }

        [HttpPut]
        public async Task<ActionResult<TableBillDto>> Put(TableBillDto dto)
        {
            var entity = await dataContext.Set<TableBill>().FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null)
            {
                return NotFound();
            }
            mapper.Map(dto, entity);
            await dataContext.SaveChangesAsync();
            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<TableBillDto>> Post(TableBillDto dto)
        {
            var entity = new TableBill();
            mapper.Map(dto, entity);
            dataContext.Add(entity);
            await dataContext.SaveChangesAsync();
            dto.Id = entity.Id;
            return dto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await dataContext.Set<TableBill>().FirstOrDefaultAsync(x => x.Id == id);
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