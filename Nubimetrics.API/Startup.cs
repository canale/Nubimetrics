using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Nubimetrics.API.Filters;
using Nubimetrics.Application.Contracts;
using Nubimetrics.Application.Services;
using Nubimetrics.DataAccess.Contracts;
using Nubimetrics.DataAccess.Helpers;
using Nubimetrics.DataAccess.Repositories;
using Nubimetrics.DataAccess.Settings;
using Nubimetrics.Domain.Contracts.Repositories;
using System;

namespace Nubimetrics.API
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

            var biopagoSettings = Configuration.GetSection("ClassifiedLocationSettings");
            services.Configure<ApiIntegrationSettings>(biopagoSettings);


            var currencySettings = Configuration.GetSection("CurrencySettings");
            services.Configure<ApiIntegrationSettings>(currencySettings);

            services.AddControllers(options => options.Filters.Add<ExceptionFilter>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nubimetrics.API", Version = "v1" });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IClassifiedLocationService, ClassifiedLocationService>();

            //Repositories
            services.AddTransient<IPaisRepository, PaisRepository>();
            services.AddTransient<IMonedaRepository, MonedaRepository>();

            //Application services
            services.AddTransient<IPaisApplicationService, PaisApplicationService>();
            services.AddTransient<IMonedaApplicationService, MonedaApplicationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nubimetrics.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
