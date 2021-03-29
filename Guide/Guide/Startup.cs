using Guide.Domain.Services;
using Guide.Domain.Services.Generic;
using Guide.Entity.Context;
using Guide.Entity.Repositories;
using Guide.Entity.Repositories.Interfaces;
using Guide.Entity.UnitofWork;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guide.Domain.Mapping;
using Guide.Domain.Interfaces;

namespace Guide
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                      new OpenApiInfo
                      {
                          Title = "Webservices Finances (Guide)",
                          Version = "v1",
                          Description = "Services Finances (Guide)",
                          Contact = new OpenApiContact
                          {
                              Name = "Diogo Rodrigues",
                          }
                      });

            });


            services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(Configuration["ConnectionStrings:clienteDB"]);
                config.UseSerializerSettings(new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            });

            services.AddDbContext<GuideContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:clienteDB"]));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(GuideService<,>), typeof(GuideService<,>));
            services.AddTransient(typeof(IServiceAsync<,>), typeof(GenericServiceAsync<,>));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));


            services.AddTransient<IGuideRepository, GuideRepository>();
            services.AddTransient<ICurrentTradingPeriodRepository, CurrentTradingPeriodRepository>();
            services.AddTransient<IQuoteIndicatorRepository, QuoteIndicatorRepository>();

            services.AddTransient<IFinanceService, FinanceServices>();
            services.AddHttpClient<IFinanceService, FinanceServices>();

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddHttpContextAccessor();
            services.AddControllers();
        }

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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Guide");
            });
        }
    }
}
