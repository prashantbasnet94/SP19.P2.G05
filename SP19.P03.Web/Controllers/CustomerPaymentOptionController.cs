using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P03.Web.Data;
using SP19.P03.Web.Dto;
using SP19.P03.Web.Features.Payments;


namespace SP19.P03.Web.Controllers
{
    [Route("CustomerPaymentOption")]
    [ApiController]
    public class CustomerPaymentOptionController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerPaymentOptionController(DataContext context)
        {
            _context = context;
        }


        // GET: api/CustomerPaymentOptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CustomerPaymentOptionsDto>>> GetCustomerPaymentOptions(int id)
        {

            return new List<CustomerPaymentOptionsDto>();
        }



        // POST: api/CustomerPaymentOptions
        [HttpPost]
        public async Task<ActionResult<CustomerPaymentOptionsDto>> PostCustomerPaymentOption(CustomerPaymentOptionsDto paymentOption)
        {
            return new CustomerPaymentOptionsDto();
        }

        // DELETE: api/CustomerPaymentOptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerPaymentOptionsDto>> DeleteCustomerPaymentOption(int id)
        {

            var paymentOption = await _context.PaymentOption.FindAsync(id);
            if (paymentOption == null)
            {
                return NotFound();
            }

            _context.PaymentOption.Remove(paymentOption);
            await _context.SaveChangesAsync();

            //return paymentOption;
            return new CustomerPaymentOptionsDto();

        }

        private bool PaymentOptionExists(int id)
        {
            return _context.PaymentOption.Any(e => e.Id == id);
        }
    }
}
