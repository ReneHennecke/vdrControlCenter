namespace vdrControlServiceWebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using vdrControlService.Models;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiSystemController : ControllerBase
    {

        public List<ApiControllerInfo> GetInterfaces()
        {
            List<ApiControllerInfo> apiControllerInfos = new List<ApiControllerInfo>();
            var types = GetType().Assembly.GetTypes();

            foreach (var t in types)
            {
                if (t.IsSubclassOf(typeof(Controller)))
                {
                    ApiControllerInfo apiControllerInfo = new ApiControllerInfo()
                    {
                        FullName = t.FullName,
                        Name = t.Name,

                    };

                    // Actions (Methods) ermitteln
                    var actions = t.GetType().GetMethods();
                    //foreach (var a in actions)
                    //{
                    //    if (a.IsPublic && !methodInfo.IsDefined(typeof(NonActionAttribute)))
                    //    {
                    //        ApiMethodInfo apiMethodInfo = new ApiMethodInfo()
                    //        {
                    //            FullName = a.Name
                    //        };
                    //        apiControllerInfo.Methods.Add(apiMethodInfo);
                    //    }
                    //}

                    // Controller, Action
                    apiControllerInfos.Add(apiControllerInfo);
                }
            }

            return apiControllerInfos;
        }

    }
}
