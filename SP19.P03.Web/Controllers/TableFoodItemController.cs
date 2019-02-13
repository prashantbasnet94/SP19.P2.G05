using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P03.Web.Data;
using SP19.P03.Web.Dto;
using SP19.P03.Web.Features.Tables;


namespace SP19.P03.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableFoodItemController : ControllerBase
    {
        private readonly DataContext _context;

        public TableFoodItemController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TableFoodItemDto>>> GetTableFoodItem(int id)
        {
            var tableFoodItem = await _context.TableFoodItem.FindAsync(id);

            if (tableFoodItem == null)
            {
                return NotFound();
            }

            return new List<TableFoodItemDto>();
        }

        // PUT: api/TableFoodItems/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TableFoodItemDto>> PutTableFoodItem(int id, TableFoodItem tableFoodItem)
        {
            if (id != tableFoodItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(tableFoodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableFoodItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TableFoodItems
        [HttpPost]
        public async Task<ActionResult<TableFoodItemDto>> PostTableFoodItem(TableFoodItem tableFoodItem)
        {
            _context.TableFoodItem.Add(tableFoodItem);
            await _context.SaveChangesAsync();

            return new TableFoodItemDto();
        }

        // DELETE: api/TableFoodItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TableFoodItemDto>> DeleteTableFoodItem(int id)
        {
            var tableFoodItem = await _context.TableFoodItem.FindAsync(id);
            if (tableFoodItem == null)
            {
                return NotFound();
            }

            _context.TableFoodItem.Remove(tableFoodItem);
            await _context.SaveChangesAsync();

            return new TableFoodItemDto();
        }

        private bool TableFoodItemExists(int id)
        {
            return _context.TableFoodItem.Any(e => e.Id == id);
        }
    }
}
