using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Zhaoxi.AspNetCore3_1.Interface;
using Zhaoxi.AspNetCore31.Demo.Utility.WebApiHelper;
using Zhaoxi.EntityFrameworkCore31.Model;

namespace Zhaoxi.AspNetCore31.Demo.Controllers
{
    public class TestController : Controller
    {
        #region Identity
        private readonly ILogger<TestController> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ITestServiceA _iTestServiceA;
        private readonly ITestServiceB _iTestServiceB;
        private readonly ITestServiceC _iTestServiceC;
        private readonly ITestServiceD _iTestServiceD;
        private readonly ITestServiceE _iTestServiceE;
        private readonly IServiceProvider _iServiceProvider;
        private readonly IConfiguration _iConfiguration;

        //private readonly DbContext _dbContext;
        private readonly IUserService _iUserService;

        public TestController(ILogger<TestController> logger,
            ILoggerFactory loggerFactory
            , ITestServiceA testServiceA
            , ITestServiceB testServiceB
            , ITestServiceC testServiceC
            , ITestServiceD testServiceD
            , ITestServiceE testServiceE
            , IServiceProvider serviceProvider
            , IConfiguration configuration
            , IUserService userService)
        //, DbContext dbContext)
        {
            this._logger = logger;
            this._loggerFactory = loggerFactory;
            this._iTestServiceA = testServiceA;
            this._iTestServiceB = testServiceB;
            this._iTestServiceC = testServiceC;
            this._iTestServiceD = testServiceD;
            this._iTestServiceE = testServiceE;
            this._iServiceProvider = serviceProvider;
            this._iConfiguration = configuration;
            //this._dbContext = dbContext;
            this._iUserService = userService;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            List<SysUser> userList = new List<SysUser>();
            string resultUrl = null;

            #region 直接调用
            {
                string url = "http://localhost:5726/api/users/get";
                string result = WebApiHelperExtend.InvokeApi(url);
                userList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SysUser>>(result);
                resultUrl = url;
            }
            #endregion

            base.ViewBag.Users = userList;
            base.ViewBag.Url = resultUrl;
            return View();
        }
    }
}