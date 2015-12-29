using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using MasteredTrax.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;

namespace MasteredTrax
{
    public class Startup
    {
        // this public property allows us to look at all the Config variables
        public static IConfigurationRoot Configuration;

        // how is this variable allowed to be injected here
        // can this only be done using the constructor
        public Startup(IApplicationEnvironment appEnv)
        {
            // a lot of magic happening here
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(opt => {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddEntityFramework()  //Adding Entity Framework specific interfaces
                .AddSqlServer() // Add Sql Server specific pieces that we need
                .AddDbContext<MastedTraxContext>();  // Add our specific context to inject to other parts of application

            services.AddTransient<MasteredTraxSeedData>();

            services.AddScoped<IMasteredTraxRepository, MasteredTraxRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, MasteredTraxSeedData seeder)
        {
            //app.UseIISPlatformHandler();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            // Middleware
            // The order in which these calls are made is very important

            // Serves Index.html
            app.UseDefaultFiles();

            // So that HTML (static files) can be served from wwwroot
            app.UseStaticFiles();

            app.UseMvc();

            seeder.EnsureSeedData();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
