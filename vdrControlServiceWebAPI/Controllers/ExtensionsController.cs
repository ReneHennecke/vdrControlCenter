// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vdrControlServiceWebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using vdrControlService.Services;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExtensionsController : ControllerBase
    {
        private readonly ILogger<ExtensionsController> _logger;
        private readonly IConfiguration _configuration;

        private ExtensionsService _service;

        public ExtensionsController(ILogger<ExtensionsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _service = new ExtensionsService();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }

            _logger.LogInformation("Disposing...");
        }


        [HttpGet()]
        public bool IsAlive()
        {
            _logger.LogTrace("Request IsAlive");
            return true;
        }

        // GET: api/<ExtensionsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ExtensionsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ExtensionsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ExtensionsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ExtensionsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
