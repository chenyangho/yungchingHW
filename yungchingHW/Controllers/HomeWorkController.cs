using Microsoft.AspNetCore.Mvc;
using yungchingHW.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yungchingHW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeWorkController : ControllerBase
    {

        private readonly WideWorldImportersContext _wideWorldImportersContext;
        public HomeWorkController(WideWorldImportersContext wideWorldImportersContext)
        {
            _wideWorldImportersContext = wideWorldImportersContext;
        }

        // GET: api/<HomeWorkController>
        [HttpGet]
        public ActionResult<IEnumerable<SpecialDeal>> Get()
        {
            return _wideWorldImportersContext.SpecialDeals.ToList();
        }

        // GET api/<HomeWorkController>/5
        [HttpGet("{id}")]
        public ActionResult<City> Get(int id)
        {
            var result = _wideWorldImportersContext.Cities.Find(id);
            if (result == null)
            {
                return NotFound("Can't find data");
            }
            return result;
        }

        // POST api/<HomeWorkController>
        [HttpPost]
        public ActionResult<City> Post([FromBody] City value)
        {
            _wideWorldImportersContext.Cities.Add(value);
            _wideWorldImportersContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = value.CityId }, value);
        }

        // PUT api/<HomeWorkController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeWorkController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
