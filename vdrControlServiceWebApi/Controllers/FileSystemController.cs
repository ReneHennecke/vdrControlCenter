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
    using vdrControlService.Models;
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
        [Produces("application/json")]
        public async Task<ActionResult> GetDirectory(FileSystemEntryRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Fehlerhafte Parameter.");

            MethodBase m = MethodBase.GetCurrentMethod();
            CreateRequestLogInfo(m, request);

            FileSystemResponse response = new FileSystemResponse()
            {
                RequestId = request.RequestId
            };

            FileSystemEntry result = await Task.Run(() =>
            {
                return _service.GetDirectory(request);
            });

            if (result == null)
                return BadRequest(response);

            response.FileSystemEntry = result;
          
            CreateResponseLogInfo(m, response);

            return Ok(response);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult> SetDirectory(FileSystemEntryRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Fehlerhafte Parameter.");

            MethodBase m = MethodBase.GetCurrentMethod();
            CreateRequestLogInfo(m, request);

            FileSystemResponse response = new FileSystemResponse()
            {
                RequestId = request.RequestId
            };

            FileSystemEntry result = await Task.Run(() =>
            {
                return _service.SetDirectory(request);
            });

            if (result == null)
                return BadRequest(response);

            response.FileSystemEntry = result;

            CreateResponseLogInfo(m, response);

            return Ok(response);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult> ReadFileContent(FileSystemEntryRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Fehlerhafte Parameter.");

            MethodBase m = MethodBase.GetCurrentMethod();
            CreateRequestLogInfo(m, request);

            FileSystemResponse response = new FileSystemResponse()
            {
                RequestId = request.RequestId
            };

            FileContent result = await Task.Run(() =>
            {
                return _service.ReadFileContent(request);
            });

            if (result == null)
                return BadRequest(response);

            response.FileContent = result;

            CreateResponseLogInfo(m, response);

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
    }
}
