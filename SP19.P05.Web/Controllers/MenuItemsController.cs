using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P05.Web.Data;
using SP19.P05.Web.Features.LineItems;
using SP19.P05.Web.Features.Menus;

namespace SP19.P05.Web.Controllers
{
    public class MenuItemsController : ApiBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public MenuItemsController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        [HttpGet("{menuId}")]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> Get(int menuId)
        {
            var entityQueryable = dataContext.Set<MenuItem>().Where(x => x.MenuId == menuId);
            var dtoQueryable = mapper.ProjectTo<MenuItemDto>(entityQueryable);
            var itemDtos = await dtoQueryable.ToArrayAsync();
            return itemDtos;
        }

        [HttpPut]
        public async Task<ActionResult<MenuItemDto>> Put(MenuItemDto dto)
        {
            var entity = await dataContext.Set<MenuItem>().FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null)
            {
                return NotFound();
            }
            mapper.Map(dto, entity);
            await dataContext.SaveChangesAsync();
            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<MenuItemDto>> Post(MenuItemDto dto)
        {
            var entity = new MenuItem();
            mapper.Map(dto, entity);
            dataContext.Add(entity);
            await dataContext.SaveChangesAsync();
            dto.Id = entity.Id;
            return dto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await dataContext.Set<MenuItem>().FirstOrDefaultAsync(x => x.Id == id);
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