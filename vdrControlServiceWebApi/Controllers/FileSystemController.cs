// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vdrControlServiceWebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Reflection;
    using vdrControlService.Services;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileSystemController : ControllerBase
    {
        private readonly ILogger<FileSystemController> _logger;
        private readonly IConfiguration _configuration;

        private FileSystemService _service;


        public FileSystemController(ILogger<FileSystemController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _service = new FileSystemService();
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
        [Produces("application/json")]
        public IActionResult GetDirEntriesInfo() //Guid requestId)
        {
            Guid requestId = Guid.NewGuid();

            //string value1 = _configuration.GetSection("Data").GetSection("CurrentPath").Value;


            MethodBase m = MethodBase.GetCurrentMethod();
            CreateRequestLogInfo(m, requestId);

            var result = _service.GetDirEntriesInfo();
            if (result == null)
                return NotFound("Not found.");

            return Ok(result);
        }

        [HttpGet()]
        [Produces("application/json")]
        public IActionResult GetDirEntriesInfoFromPath(Guid requestId, string fullPath)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            CreateRequestLogInfo(m, requestId);

            var result = _service.GetDirEntriesInfo(fullPath);
            if (result == null)
                return NotFound($"Path {fullPath} not found.");

            return Ok(result);
        }

        private void CreateLogInfo(MethodBase m, string message)
        {
            _logger.LogInformation($"{m.Name}|{message}");
        }

        private void CreateRequestLogInfo(MethodBase m, Guid requestId)
        {
            string msg = $"{m.Name}|{requestId}";
            _logger.LogInformation(msg);
        }


        //private HttpResponseMessage BuildResponseMessage(ResponseResult responseResult)
        //{
        //    string json = JsonConvert.SerializeObject(responseResult);
        //    HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK);
        //    httpResponse.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        //    return httpResponse;
        //}

        //// GET: api/<FileSystemController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<FileSystemController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<FileSystemController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<FileSystemController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<FileSystemController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
