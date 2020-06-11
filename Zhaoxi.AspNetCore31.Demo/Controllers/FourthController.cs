using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zhaoxi.AspNetCore31.Demo.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Zhaoxi.AspNetCore31.Demo.Utility;
using Microsoft.Extensions.Logging;
using Zhaoxi.EntityFrameworkCore31.Model;
using Microsoft.EntityFrameworkCore;

namespace Zhaoxi.AspNetCore31.Demo.Controllers
{
    public class FourthController : Controller
    {
        private readonly ILogger<FourthController> _logger;
        private readonly DbContext _dbContext;
        public FourthController(ILogger<FourthController> logger,
            DbContext dbContext)
        {
            this._logger = logger;
            this._dbContext = dbContext;
        }

        public IActionResult Index()
        {
            //using (JDDbContext context = new JDDbContext())
            //{
            //    var temp = context.Set<SysUser>().FirstOrDefault(x => x.Id > 1);
            //    ViewBag.User = temp;
            //}

            var temp = _dbContext.Set<SysUser>().FirstOrDefault(x => x.Id > 1);
             ViewBag.User = temp;
            return View();
        }

        [HttpGet]//响应get请求
        public ViewResult Login()
        {
            return View();
        }


        public ActionResult Login(string name, string password, string verify)
        {
            string verifyCode = base.HttpContext.Session.GetString("CheckCode");
            if (verifyCode != null && verifyCode.Equals(verify, StringComparison.CurrentCultureIgnoreCase))
            {
                if ("Eleven".Equals(name) && "123456".Equals(password))
                {
                    CurrentUser currentUser = new CurrentUser()
                    {
                        Id = 123,
                        Name = "Eleven",
                        Account = "Administrator",
                        Email = "57265177",
                        Password = "123456",
                        LoginTime = DateTime.Now
                    };

                    //base.HttpContext.SetCookies("CurrentUser", Newtonsoft.Json.JsonConvert.SerializeObject(currentUser), 30);
                    //base.HttpContext.Session.SetString("CurrentUser", Newtonsoft.Json.JsonConvert.SerializeObject(currentUser));

                    var claims = new List<Claim> {
                      new Claim(ClaimTypes.Name,name),
                        new Claim("password",password),//可以写入任意数据
                        new Claim("Account","Administrator")
                    };

                    var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Customer"));
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                    }).Wait();//没用await
                    return base.Redirect("/Home/Index");
                }
                else
                {
                    base.ViewBag.Msg = "账号密码错误";
                }
            }
            else
            {
                base.ViewBag.Msg = "验证码错误";
            }
            return View();
        }

        [HttpPost]
        //[CustomAllowAnonymous]
        public ActionResult Logout()
        {
            #region Cookie
            base.HttpContext.Response.Cookies.Delete("CurrentUser");
            #endregion Cookie

            #region Session
            CurrentUser sessionUser = base.HttpContext.GetCurrentUserBySession();
            if (sessionUser != null)
            {
                this._logger.LogDebug(string.Format("用户id={0} Name={1}退出系统", sessionUser.Id, sessionUser.Name));
            }
            base.HttpContext.Session.Remove("CurrentUser");
            base.HttpContext.Session.Clear();
            #endregion Session

            #region MyRegion
            //HttpContext.User.Claims//其他信息
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            #endregion
            return RedirectToAction("Index", "Home"); ;
        }

        public ActionResult VerifyCode()
        {
            string code = "";
            Bitmap bitmap = Utility.VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session.SetString("CheckCode", code);
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");
        }
    }
}
