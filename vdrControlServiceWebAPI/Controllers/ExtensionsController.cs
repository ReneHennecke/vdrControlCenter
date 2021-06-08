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
            return true;
        }
    }
}
