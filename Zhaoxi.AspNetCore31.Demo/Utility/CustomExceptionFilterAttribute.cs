using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zhaoxi.AspNetCore31.Demo.Utility
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {

        private readonly ILogger<CustomExceptionFilterAttribute> _logger;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger
            , IModelMetadataProvider modelMetadataProvider)
        {
            _logger = logger;
            this._modelMetadataProvider = modelMetadataProvider;
        }

        public override void OnException(ExceptionContext context)
        {
            this._logger.LogError($"{context.HttpContext.Request.RouteValues["controller"]} is Error");
            if (!context.ExceptionHandled) {

                if (this.IsAjaxRequest(context.HttpContext.Request)) {
                    context.Result = new JsonResult(
                        new
                        {
                            Result = "False",
                            Msg = context.Exception.Message
                        }
                    );
                }
                else{
                    //context.Result = new RedirectResult("/Home/Index");
                    var result = new ViewResult { ViewName = "~/Views/Shared/Error.cshtml" };
                    result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
                    result.ViewData.Add("Exception", context.Exception);
                    context.Result = result;
                }
                
                context.ExceptionHandled = true;
            }
            
        }

        private bool IsAjaxRequest(HttpRequest request)
        {
            string header = request.Headers["X-Requested-With"];
            return "XMLHttpRequest".Equals(header);
        }
    }
}
