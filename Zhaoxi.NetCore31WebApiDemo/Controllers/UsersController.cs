using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Zhaoxi.AspNetCore3_1.Interface;
using Zhaoxi.EntityFrameworkCore31.Model;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Zhaoxi.AspNetCore31.Demo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private ILoggerFactory _Factory = null;
        private ILogger<UsersController> _logger = null;
        private ITestServiceA _ITestServiceA = null;
        private ITestServiceB _ITestServiceB = null;
        private ITestServiceC _ITestServiceC = null;
        private ITestServiceD _ITestServiceD = null;
        private IUserService _IUserService = null;
        private List<SysUser> _userList = null;
        private readonly IConfiguration _iConfiguration;
        private readonly IUserService _iUserService;
        public ITestServiceA ITestServiceA { get; set; }
        public UsersController(ILoggerFactory factory,
            ILogger<UsersController> logger,
            ITestServiceA testServiceA,
            ITestServiceB testServiceB,
            ITestServiceC testServiceC,
            ITestServiceD testServiceD,
            IConfiguration configuration
            , IUserService userService)
        {
            this._Factory = factory;
            this._logger = logger;
            this._ITestServiceA = testServiceA;
            this._ITestServiceB = testServiceB;
            this._ITestServiceC = testServiceC;
            this._ITestServiceD = testServiceD;
            this._IUserService = userService;
            this._iConfiguration = configuration;
            this._iUserService = userService;

            this._userList = this._iUserService.Query<Zhaoxi.EntityFrameworkCore31.Model.SysUser>(u => u.Id > 1)
                                        .OrderBy(u => u.Id)
                                        .Skip(1)
                                        .Take(5)
                                        .Select(u => new SysUser()
                                        {
                                            Id = u.Id,
                                            Email = u.Email,
                                            Name = u.Name
                                        }).ToList();
        }

        // GET api/Users
        [HttpGet]
        public IEnumerable<SysUser> Get()
        {
            return _userList;
        }

    }
}
public class Users
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
}
