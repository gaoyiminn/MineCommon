using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Zhaoxi.AspNetCore3_1.Interface;
using Zhaoxi.AspNetCore31.Demo.Utility;

namespace Zhaoxi.AspNetCore31.Demo.Controllers
{
    public class ThirdController : Controller
    {

        private readonly ILogger<ThirdController> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ITestServiceA _iTestServiceA;
        private readonly ITestServiceB _iTestServiceB;
        private readonly ITestServiceC _iTestServiceC;
        private readonly ITestServiceD _iTestServiceD;
        private readonly ITestServiceE _iTestServiceE;
        private readonly IServiceProvider _iServiceProvider;
        private readonly IConfiguration _iConfiguration;
        /// <summary>
        /// 来自DI依赖注入---构造函数注入---构造A对象依赖B对象，自动初始化B对象传入
        /// 
        /// 有个容器，负责构造SecondController(反射)--反射构造函数--需要B--再构造B---然后再构造A
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="loggerFactory"></param>
        public ThirdController(ILogger<ThirdController> logger,
            ILoggerFactory loggerFactory
            , ITestServiceA testServiceA
            , ITestServiceB testServiceB
            , ITestServiceC testServiceC
            , ITestServiceD testServiceD
            , ITestServiceE testServiceE
            , IServiceProvider serviceProvider
            , IConfiguration configuration)
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
        }

        public IActionResult Index()
        {
            this._logger.LogWarning("third index");

            string AllowedHosts = this._iConfiguration["AllowedHosts"];
            string writeConn = this._iConfiguration["ConnectionStrings:Write"];
            string readConn = this._iConfiguration["ConnectionStrings:Read:0"];
            string[] _SqlConnectionStringRead = this._iConfiguration.GetSection("ConnectionStrings").GetSection("Read").GetChildren().Select(x => x.Value).ToArray();
            string allowedHost = this._iConfiguration["AllowedHost"].ToString();
            return View();
        }

        public IActionResult Test()
        {
            int i = 0;
            int b = 8 / i;
            return View();
        }
    }
}
