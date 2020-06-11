using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Zhaoxi.AspNetCore3_1.Interface;
using Zhaoxi.AspNetCore3_1.Service;
using Zhaoxi.AspNetCore31.Demo.Utility;
using Zhaoxi.EntityFrameworkCore31.Model;

namespace Zhaoxi.AspNetCore31.Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddControllersWithViews(option =>
            {
                option.Filters.Add<CustomExceptionFilterAttribute>();
            }).AddRazorRuntimeCompilation();//修改cshtml后能自动编译;

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = new PathString("/Fourth/Login");
                    options.AccessDeniedPath = new PathString("/Home/Privacy");
                });

            services.AddScoped<DbContext, JDDbContext>();

            //services.AddDbContext<JDDbContext>(options => {
            //    options.UseSqlServer(Configuration.GetConnectionString("JDDbConnection"));
            //});

            //services.AddScoped(typeof(CustomExceptionFilterAttribute));
        }


        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterType<TestServiceE>().As<ITestServiceE>().SingleInstance();
            containerBuilder.RegisterModule<CustomAutofacModule>();
            //containerBuilder.RegisterType<TestServiceA>().As<ITestServiceA>().SingleInstance().PropertiesAutowired();
            //containerBuilder.RegisterType<TestServiceC>().As<ITestServiceC>();
            //containerBuilder.RegisterType<TestServiceB>().As<ITestServiceB>();
            //containerBuilder.RegisterType<TestServiceD>().As<ITestServiceD>();
            //containerBuilder.RegisterType<TestServiceE>().As<ITestServiceE>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            loggerFactory.AddLog4Net();
            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
