using AutoMapper;
using AutoMapperApı.Context;
using AutoMapperApı.DTO;
using AutoMapperApı.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperApı.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private CustomerContext _context;
        IMapper _mapper;
        public CustomerController(CustomerContext customercontext, IMapper mapper)
        {
            _context = customercontext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDTO>>> GetCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            return _mapper.Map<List<CustomerDTO>>(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return _mapper.Map<CustomerDTO>(customer);
        }
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

          
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);

          
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
