// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vdrControlServiceWebAPI.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using vdrControlService;
    using vdrControlService.Model;
    using vdrControlService.Models;
    using vdrControlService.Models.Requests;
    using vdrControlService.Models.Responses;
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

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetCurrentDirectory(CurrentDirectoryRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Fehlerhafte Parameter.");

            MethodBase m = MethodBase.GetCurrentMethod();
            CreateRequestLogInfo(m, request);

            //ApiResponse response = new ApiResponse()
            //{
            //    RequestId = request.RequestId
            //};

            //DirEntryInfoResult result = await Task.Run(() =>
            //{
            //    return _service.GetCurrentDirectory();
            //});


            //response.
            //if (result == null)
            //    return BadRequest(response);

            //result.DirEntryInfo.FullName = result.DirEntryInfo.FullName.Replace("*", string.Empty);
            //response.DirEntryInfoResult = result;



            // CreateResponseLogInfo(m, response);

            Arschloch a = new Arschloch();
            a.FileSystemInfo = new DirectoryInfo("D:\\temp");

            return Ok(a);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult SetCurrentDirectory(CurrentDirectoryRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Fehlerhafte Parameter.");

            MethodBase m = MethodBase.GetCurrentMethod();
            CreateRequestLogInfo(m, request);

            CurrentDirectoryResponse response = new CurrentDirectoryResponse()
            {
                RequestId = request.RequestId
            };


            //var result = await Task.Run(() =>
            //{
            //    return _service.SetCurrentDirectory(request.FullPath);
            //});
            //if (result == null)
              //  return BadRequest(response);

            //result.DirEntryInfo.FullName = result.DirEntryInfo.FullName.Replace("*", string.Empty);
            //response.DirEntryInfoResult = result;

            CreateResponseLogInfo(m, response);

            return Ok(response);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult> GetDirEntriesInfo(DirEntriesInfoRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Fehlerhafte Parameter.");

            MethodBase m = MethodBase.GetCurrentMethod();
            CreateRequestLogInfo(m, request);

            ApiResponse response = new ApiResponse()
            {
                RequestId = request.RequestId
            };

            if (string.IsNullOrWhiteSpace(request.FullPath))
                request.FullPath = Directory.GetCurrentDirectory();


            if (string.IsNullOrWhiteSpace(request.FullPath))
            {
                response.ErrorResult.ErrorCode = vdrControlService.Enums.ErrorResultCode.CurrentDirectoryError;
                return BadRequest(response);
            }

            if (!Directory.Exists(request.FullPath))
            {
                response.ErrorResult.ErrorCode = vdrControlService.Enums.ErrorResultCode.CurrentDirectoryError;
                return BadRequest(response);
            }


            var result = await Task.Run(() =>
            {
                return _service.GetDirEntriesInfo(request.FullPath);
            });
            if (result == null)
                return BadRequest(response);


            ////response.Response = result;

            return Ok(response);
        }

        private void CreateLogInfo(MethodBase m, string message)
        {
            _logger.LogInformation($"{m.Name}|{message}");
        }

        private void CreateRequestLogInfo(MethodBase m, ApiRequest request)
        {
            string msg = $"{m.Name}|{request.RequestId}";
            _logger.LogInformation(msg);
        }

        private void CreateResponseLogInfo(MethodBase m, ApiResponse response)
        {
            string msg = $"{m.Name}|{response.RequestId}|{response.ResponseId}|";
            if (response.ErrorResult.Success)
            {
                msg += $"{response.ErrorResult.Success}";
                _logger.LogInformation(msg);
            }
            else
            {
                msg += $"{response.ErrorResult.ErrorCode}|{response.ErrorResult.ErrorMessage}|{response.ErrorResult.ErrorException}";
                _logger.LogError(msg);
            }
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
