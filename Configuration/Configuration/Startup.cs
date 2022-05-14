using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration
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
            services.Configure<ApiOption>(Configuration.GetSection("MyAPI"));
            //services.AddSingleton<ApiOption, ApiOption>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Console.WriteLine($"MyKey value : {Configuration["MyKey"]}");
            //Console.WriteLine($"My Api values : {Configuration["MyAPI:url"]}");
            //Console.WriteLine($"My Api values : {Configuration["MyAPI:ApiKey"]}");

            //var option = new ApiOption();
            //Configuration.GetSection("MyApi").Bind(option);
            //Console.WriteLine($"MyApi.url :{option.url}");
            //Console.WriteLine($"MyApi.ApiKey :{option.ApiKey}");

            //OR

            var apiOption = Configuration.GetSection("MyApi").Get<ApiOption>();
            Console.WriteLine($"MyApi.url :{apiOption.url}");
            Console.WriteLine($"MyApi.ApiKey :{apiOption.ApiKey}");

            Console.WriteLine($"From MySettings : {Configuration["MySetting:SettingKey"]}");

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
