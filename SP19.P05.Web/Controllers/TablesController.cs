using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P05.Web.Data;
using SP19.P05.Web.Features.Tables;

namespace SP19.P05.Web.Controllers
{
    public class TablesController : ApiBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public TablesController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableDto>>> Get()
        {
            var entityQueryable = dataContext.Set<Table>();
            var dtoQueryable = mapper.ProjectTo<TableDto>(entityQueryable);
            var itemDtos = await dtoQueryable.ToArrayAsync();
            return itemDtos;
        }

        [HttpPut]
        public async Task<ActionResult<TableDto>> Put(TableDto dto)
        {
            var entity = await dataContext.Set<Table>().FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null)
            {
                return NotFound();
            }
            mapper.Map(dto, entity);
            await dataContext.SaveChangesAsync();
            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<TableDto>> Post(TableDto dto)
        {
            var entity = new Table();
            mapper.Map(dto, entity);
            dataContext.Add(entity);
            await dataContext.SaveChangesAsync();
            dto.Id = entity.Id;
            return dto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await dataContext.Set<Table>().FirstOrDefaultAsync(x => x.Id == id);
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