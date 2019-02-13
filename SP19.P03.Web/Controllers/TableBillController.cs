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
    [Route("TableBill")]
    [ApiController]
    public class TableBillsController : ControllerBase
    {
        private readonly DataContext _context;

        public TableBillsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TableBills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableBillDto>>> GetTableBill()
        {
            return new List<TableBillDto>();
        }

        // GET: api/TableBills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TableBillDto>> GetTableBill(int id)
        {
            var tableBill = await _context.TableBill.FindAsync(id);

            if (tableBill == null)
            {
                return NotFound();
            }

            return new TableBillDto();
        }

        // PUT: api/TableBills/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TableBillDto>> PutTableBill(int id, TableBill tableBill)
        {
            if (id != tableBill.Id)
            {
                return BadRequest();
            }

            _context.Entry(tableBill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableBillExists(id))
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

        // POST: api/TableBills
        [HttpPost]
        public async Task<ActionResult<TableBillDto>> PostTableBill(TableBill tableBill)
        {
            _context.TableBill.Add(tableBill);
            await _context.SaveChangesAsync();

            return new TableBillDto();
        }

        // DELETE: api/TableBills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TableBillDto>> DeleteTableBill(int id)
        {
            var tableBill = await _context.TableBill.FindAsync(id);
            if (tableBill == null)
            {
                return NotFound();
            }

            _context.TableBill.Remove(tableBill);
            await _context.SaveChangesAsync();

            return new TableBillDto();
        }

        private bool TableBillExists(int id)
        {
            return _context.TableBill.Any(e => e.Id == id);
        }
    }
}
