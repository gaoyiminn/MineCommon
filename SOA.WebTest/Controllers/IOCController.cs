using SOA.Interface;
using SOA.Service;
using SOA.WebTest.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;
namespace SOA.WebTest.Controllers
{
    public class IOCController : ApiController
    {

        private IUserService _userService;

        public IOCController(IUserService userService)
        {
            this._userService = userService;
        }

        public object Get(int id) {
            //IUserService userService = ContainerFactory.BuildContainer().Resolve<IUserService>();
            //IUserService userService = new UserService();
            return _userService.Query(id);
        }
    }
}
