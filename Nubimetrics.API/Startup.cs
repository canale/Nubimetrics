using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Nubimetrics.API.Filters;
using Nubimetrics.Application.Contracts;
using Nubimetrics.Application.Services;
using Nubimetrics.DataAccess.Repositories;
using Nubimetrics.Domain.Contracts.Repositories;
using Nubimetrics.Infrastructure.Contracts;
using Nubimetrics.Infrastructure.Services.Integrations;
using Nubimetrics.Infrastructure.Settings;
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
            //Settings
            var biopagoSettings = Configuration.GetSection("ClassifiedLocationSettings");
            services.Configure<ClassifiedLocationSettings>(biopagoSettings);

            var currencySettings = Configuration.GetSection("CurrencySettings");
            services.Configure<CurrencySettings>(currencySettings);

            var currencyConversionSettings = Configuration.GetSection("currencyConversionSettings");
            services.Configure<CurrencyConversionSettings>(currencyConversionSettings);



            services.AddControllers(options => options.Filters.Add<ExceptionFilter>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nubimetrics.API", Version = "v1" });
            });


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Integration
            services.AddTransient<IClassifiedLocationService, ClassifiedLocationService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<ICurrencyConversionService, CurrencyConversionService>();

            //Repositories
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();

            //Application services
            services.AddTransient<ICountryApplicationService, CountryApplicationService>();
            services.AddTransient<ICurrencyApplicationService, CurrencyApplicationService>();
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
