namespace vdrControlServiceWebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using vdrControlService.Models;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiSystemController : ControllerBase
    {
        private readonly ILogger<ApiSystemController> _logger;
        private readonly IConfiguration _configuration;

        public ApiSystemController(ILogger<ApiSystemController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
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
        public List<ApiHelpEndpoint> GetApiHelpEndpoints()
        {
            List<ApiHelpEndpoint> apiHelpEndpoints = new List<ApiHelpEndpoint>();

            Assembly assembly = Assembly.GetExecutingAssembly();

            assembly.GetTypes()
                    .Where(type => typeof(ControllerBase).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .ToList()
                    .Select(x =>
                    {
                        return new ApiHelpEndpoint()
                        {
                            Controller = x.DeclaringType.Name.Replace("Controller", string.Empty),
                            Action = x.Name,
                            ReturnType = x.ReturnType.Name,
                            Attributes = string.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", string.Empty)))//,
                            //DisplayableName = x.GetCustomAttributes<DisplayAttribute>().FirstOrDefault()?.Name ?? x.Name,
                            //Description = x.GetCustomAttributes<DescriptionAttribute>().FirstOrDefault()?.Description ?? string.Empty,
                            //Properties = x.ReturnType.GenericTypeArguments.FirstOrDefault()?.GetProperties()
                        };
                    })
                    .Where(x => x.Action.ToLower() != "dispose")
                    .OrderBy(x => x.Controller)
                    .ThenBy(x => x.Action)
                    .ToList()
                    .ForEach(x => apiHelpEndpoints.Add(x));

            //ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
            //        .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
            //Assembly.GetAssembly(typeof(Controller)).GetTypes()
            //        .Where(type => type.IsSubclassOf(typeof(Controller)))
            //        .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
            //        .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
            //        .Select(x =>
            //        {
            //            var type = x.ReturnType.GenericTypeArguments.FirstOrDefault();
            //            var metadataType = type.GetCustomAttributes(typeof(MetadataTypeAttribute), true)
            //                                   .OfType<MetadataTypeAttribute>().FirstOrDefault();
            //            //var metaData = (metadataType != null)
            //            //               ? ModelMetadataProviders.Current.GetMetadataForType(null, metadataType.MetadataClassType)
            //            //               : ModelMetadataProviders.Current.GetMetadataForType(null, type);

            //            return new ApiHelpEndpoint()
            //            {
            //                Endpoint = x.DeclaringType.Name.Replace("Controller", string.Empty),
            //                Controller = x.DeclaringType.Name,
            //                Action = x.Name,
            //                DisplayableName = x.GetCustomAttributes<DisplayAttribute>().FirstOrDefault()?.Name ?? x.Name,
            //                Description = x.GetCustomAttributes<DescriptionAttribute>().FirstOrDefault()?.Description ?? string.Empty,
            //                Properties = x.ReturnType.GenericTypeArguments.FirstOrDefault()?.GetProperties()//,
            //                //PropertyDescription = metaData.Properties.Select(e =>
            //                //{
            //                //    var m = metaData.ModelType.GetProperty(e.PropertyName)
            //                //                    .GetCustomAttributes(typeof(DescriptionAttribute), true)
            //                //                    .FirstOrDefault();
            //                //    return m != null ? ((DescriptionAttribute)m).Description : string.Empty;
            //                //}).ToList()
            //            };
            //        })
            //        .OrderBy(x => x.Controller)
            //        .ThenBy(x => x.Action)
            //        .ToList()
            //        .ForEach(x => apiHelpEndpoints.Add(x));

            return apiHelpEndpoints;
        }
    }
}
