using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToCoffee.Model;
using OdeToCoffee.Model.DataProviders;
using OdeToCoffee.Services;

namespace OdeToCoffee
{
    public class Startup
    {
        private IConfiguration config;

        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath)
                                                    .AddJsonFile("appsettings.json")
                                                    .AddEnvironmentVariables();

            this.config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(this.config);
            services.AddSingleton<IMessageGetter, MessageFromConfigGetter>();
            services.AddScoped<ICoffehouseDataProvider, SqlCoffeehouseDataProvider>();
            services.AddDbContext<OdeToCoffeeDbContext>(options => options.UseSqlServer(this.config.GetConnectionString("DefaultConnection")));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                                IHostingEnvironment env, 
                                ILoggerFactory loggerFactory,
                                IMessageGetter messageGetter)
        {
            loggerFactory.AddConsole();

            app.UseFileServer();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions()
                {
                    ExceptionHandler = context => context.Response.WriteAsync("Niestety, coś poszło nie tak.")
                });
            }

            app.UseMvc(this.ConfigureRoutes());

            app.Run(ctx => ctx.Response.WriteAsync("Not found."));
        }

        private Action<IRouteBuilder> ConfigureRoutes()
        {
            return builder => builder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
