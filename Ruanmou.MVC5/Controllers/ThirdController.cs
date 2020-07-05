using Ruanmou.Bussiness.Interface;
using Ruanmou.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ruanmou.MVC5.Controllers
{
    public class ThirdController : Controller
    {
        private IUserService _iUserService = null;
        public ThirdController(IUserService userService)
        {
            this._iUserService = userService;
        }

        // GET: Third
        public ActionResult Index()
        {
            IUserService service = this._iUserService;
            User user = service.Find<User>(2);
            return View();
        }
    }
}