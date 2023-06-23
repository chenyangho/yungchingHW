using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using yungchingHW.Dtos;
using yungchingHW.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yungchingHW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeWorkController : ControllerBase
    {

        private readonly PubsContext _pubsContext;
        public HomeWorkController(PubsContext pubsContext)
        {
            _pubsContext = pubsContext;
        }

        // GET: api/<HomeWorkController>
        [HttpGet]
        public IEnumerable<CustomerDto> Get()
        {
            var result = _pubsContext.Customers
                .Select(data => new CustomerDto
                {
                    CustomerId = data.CustomerId,
                    CompanyName = data.CompanyName,
                    ContactName = data.ContactName,
                    ContactTitle = data.ContactTitle,
                    Address = data.Address,
                    City = data.City,
                    Region = data.Region,
                    PostalCode = data.PostalCode,
                    Country = data.Country,
                    Phone = data.Phone,
                    Fax = data.Fax
                });
            return result;
        }

        // GET api/<HomeWorkController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(string id)
        {
            var result = _pubsContext.Customers.Find(id);
            if (result == null)
            {
                return NotFound("Can't find data");
            }
            return result;
        }

        // POST api/<HomeWorkController>
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer value)
        {
            _pubsContext.Customers.Add(value);
            _pubsContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = value.CustomerId }, value);
        }

        // PUT api/<HomeWorkController>/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(string id, [FromBody] Customer value)
        {
            if (id != value.CustomerId)
            {
                return BadRequest();
            }

            _pubsContext.Entry(value).State = EntityState.Modified;

            try{
                _pubsContext.SaveChanges();
            }
            catch(DbUpdateException){
                if (!_pubsContext.Customers.Any(e=>e.CustomerId == id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }

            return NoContent();
        }

        // DELETE api/<HomeWorkController>/5
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(string id)
        {
            var delete = _pubsContext.Customers.Find(id);
            if (delete == null)
            {
                return NotFound();
            }

            _pubsContext.Remove(delete);
            _pubsContext.SaveChanges();
            return NoContent();
        }
    }
}
