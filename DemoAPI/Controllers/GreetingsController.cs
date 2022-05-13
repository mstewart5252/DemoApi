using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        private ILogger _logger;

        public GreetingsController(ILogger<GreetingsController> logger)
        {
            _logger = logger;
        }
        //// GET: api/<GreetingsController>
        //[HttpGet]
        //public IEnumerable<string> Get(string firstName = "", string lastName = "")
        //{
        //    List<string> output = new List<string>();
        //    if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
        //    {
        //        output.Add($"Hello {firstName} {lastName}");
        //    }
        //    else
        //    {
        //        output.Add("Hello world!");
        //    }
        //    return output;
        //}

        // GET api/<GreetingsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GreetingsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _logger.LogInformation(value);
        }

        // PUT api/<GreetingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GreetingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
