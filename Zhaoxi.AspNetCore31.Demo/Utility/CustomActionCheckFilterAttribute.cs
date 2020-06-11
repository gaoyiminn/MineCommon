using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Zhaoxi.AspNetCore31.Demo.Models;

namespace Zhaoxi.AspNetCore31.Demo.Utility
{
    public class CustomActionCheckFilterAttribute: ActionFilterAttribute
    {

        private readonly ILogger<CustomActionCheckFilterAttribute> _logger;


        public CustomActionCheckFilterAttribute(ILogger<CustomActionCheckFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            CurrentUser currentUser = context.HttpContext.GetCurrentUserBySession();
            if (currentUser == null)
            {
                //if (this.IsAjaxRequest(context.HttpContext.Request))
                //{ }
                context.Result = new RedirectResult("/Fourth/Login");
            }
            else
            {
                this._logger.LogDebug($"{currentUser.Name} 访问系统");
            }
        }

        private bool IsAjaxRequest(HttpRequest request)
        {
            string header = request.Headers["X-Requested-With"];
            return "XMLHttpRequest".Equals(header);
        }
    }
}
