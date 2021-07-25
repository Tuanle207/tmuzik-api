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
using Microsoft.OpenApi.Models;
using Tmuzik.Api.Configurations;
using Tmuzik.Api.SignalR;
using Tmuzik.Data;
using Tmuzik.Services.Dto;

namespace Tmuzik.Api
{
    public class Startup
    {
        private const string DefaultPolicy = "DefaultPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt => opt.AddPolicy(DefaultPolicy, builder => 
            {
                builder
                    .WithOrigins(Configuration["Url:CorsOrigins"].Split(','))
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));

            services.AddJwtAuthentication(Configuration);

            services.AddControllers();

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Configuration["ConnectionStrings:Default"]));

            services.AddAutoMapper(typeof(DummyDto).Assembly);

            services.AddServiceResolvers();

            services.AddApplicationServices();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tmuzik.Api", Version = "v1" });
            });
            
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tmuzik.Api v1"));
            }

            // app.UseHttpsRedirection();

            app.UseCors(DefaultPolicy);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}
