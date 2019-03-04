using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P05.Web.Data;
using SP19.P05.Web.Features.LineItems;
using SP19.P05.Web.Features.Tables;

namespace SP19.P05.Web.Controllers
{
    public class TableFoodItemController : ApiBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public TableFoodItemController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        [HttpGet("{tableBillId}")]
        public async Task<ActionResult<IEnumerable<TableFoodItemDto>>> Get(int tableBillId)
        {
            var entityQueryable = dataContext.Set<TableFoodItem>().Where(x => x.TableBillId == tableBillId);
            var dtoQueryable = mapper.ProjectTo<TableFoodItemDto>(entityQueryable);
            var itemDtos = await dtoQueryable.ToArrayAsync();
            return itemDtos;
        }

        [HttpPut]
        public async Task<ActionResult<TableFoodItemDto>> Put(TableFoodItemDto dto)
        {
            var entity = await dataContext.Set<TableFoodItem>().FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null)
            {
                return NotFound();
            }
            mapper.Map(dto, entity);
            await dataContext.SaveChangesAsync();
            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<TableFoodItemDto>> Post(TableFoodItemDto dto)
        {
            var entity = new TableFoodItem();
            var menuItem = await dataContext.Set<MenuItem>().FirstOrDefaultAsync(x => x.Id == dto.MenuItemId);
            mapper.Map(dto, entity);
            dataContext.Add(entity);
            await dataContext.SaveChangesAsync();
            dto.Id = entity.Id;
            dto.MenuItemName = menuItem.Name;
            return dto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await dataContext.Set<TableFoodItem>().FirstOrDefaultAsync(x => x.Id == id);
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