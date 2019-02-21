using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P03.Web.Data;
using SP19.P03.Web.Dto;
using SP19.P03.Web.Features.Customers;


namespace SP19.P03.Web.Controllers
{
    [Route("Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CustomerController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;  
        }

        // GET: api/Customers
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> ListAll()
        {
            var customer = _context.Customer;

            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customer));
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public  ActionResult<CustomerDto> GetCustomer(int id)
        {
            var customer = _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            //return customer;
            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerDto customerDto)
        {

            var customer = _context.Customer.FindAsync(id);

            if (id != customer.Id)
            {
                return BadRequest();
            }

            await _mapper.Map(customerDto, customer);

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return Ok(_mapper.Map<CustomerDto>(customer));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> PostCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return new CustomerDto();
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
