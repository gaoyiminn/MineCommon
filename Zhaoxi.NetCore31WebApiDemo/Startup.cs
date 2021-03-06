using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Zhaoxi.AspNetCore3_1.Interface;
using Zhaoxi.AspNetCore3_1.Service;
using Zhaoxi.EntityFrameworkCore31.Model;

namespace Zhaoxi.NetCore31WebApiDemo
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
            services.AddControllers();
            services.AddScoped<DbContext, JDDbContext>();//下面这套还不是把我封装了一下


            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<JDDbContext>(options=> {
                options.UseSqlServer(Configuration.GetConnectionString("JDDbConnection"));
            });

            services.AddTransient<ITestServiceA, TestServiceA>();//瞬时
            services.AddSingleton<ITestServiceB, TestServiceB>();//单例
            services.AddScoped<ITestServiceC, TestServiceC>();//作用域单例--一次请求一个实例
            //作用域其实依赖于ServiceProvider（这个自身是根据请求的），跟多线程没关系
            services.AddTransient<ITestServiceD, TestServiceD>();
            services.AddTransient<ITestServiceE, TestServiceE>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
