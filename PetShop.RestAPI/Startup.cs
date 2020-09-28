using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Data;

namespace PetShop.RestAPI
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
            services.AddCors(options =>
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                    })
            );

            //   • Allow a specific origin (the URL must be specified without
            //    a trailing slash)
            // builder => builder.WithOrigins("http://example.com");
            //    • Allow two origins
            // builder => builder.WithOrigins("http://example.com",
            //  "http://www.contoso.com"));
            //    • Allow a specific origin and all its subdomains:
            // builder => builder.WithOrigins("http://*.example.com")
            //    .SetIsOriginAllowedToAllowWildcardSubdomains());
            // (The above example also demonstrates
            // that CorsPolicyBuilder methods can be chained) 

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                FakeDB.InitData();
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
