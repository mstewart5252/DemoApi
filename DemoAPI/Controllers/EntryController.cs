using DemoLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private ILogger _logger;

        public EntryController(ILogger<EntryController> logger)
        {
            _logger = logger;
        }

        // GET: api/<EntryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EntryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EntryController>
        [HttpPost]
        [Route("Person")]
        public void Post([FromBody] PersonModel value)
        {
            _logger.LogInformation(value.PersonInfo);
        }

        // POST api/<EntryController>
        [HttpPost]
        [Route("Address")]
        public void Post([FromBody] AddressModel address)
        {
            _logger.LogInformation(address.FullAddress);
        }

        // PUT api/<EntryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EntryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
