using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P03.Web.Data;
using SP19.P03.Web.Features.Tables;
using SP19.P03.Web.Dto;
using AutoMapper;
using System.Diagnostics;

namespace SP19.P03.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TableController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Tables
        [HttpGet]
        public ActionResult<IEnumerable<TableDto>> ListAll()
        {

            var table = _context.Table;
            //    return
            return Ok(_mapper.Map<IEnumerable<TableDto>>(table));
            // return await new List<TableDto>();
        }

        // GET: api/Tables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TableDto>> List(int id)
        {
           
            var table = await _context.Table.FindAsync(id);

            if (table == null)
            {
                return NotFound();
            }
            Debug.WriteLine("<<<<<<<<<<<<<Inside line id>>>>>>>>");
            return Ok(_mapper.Map<TableDto>(table));
        }

        // PUT: api/Tables/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TableDto>> PutTable(int id, TableDto tableDto)
        {

            var table = await _context.Table.FindAsync(id);
            if (id != table.Id)
            {
                return BadRequest();
            }

            _mapper.Map(tableDto, table);

          // _context.Entry(table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(_mapper.Map<TableDto>(table));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

           // return NoContent();
        }

        // POST: api/Tables
        [HttpPost]
        public async Task<ActionResult<TableDto>> PostTable(Table table)
        {
            _context.Table.Add(table);
            await _context.SaveChangesAsync();

            return new TableDto();
        }

        // DELETE: api/Tables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TableDto>> DeleteTable(int id)
        {
            var table = await _context.Table.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            _context.Table.Remove(table);
            await _context.SaveChangesAsync();

            return new TableDto();
        }

        private bool TableExists(int id)
        {
            return _context.Table.Any(e => e.Id == id);
        }
    }
}
