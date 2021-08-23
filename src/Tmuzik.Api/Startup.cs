using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Tmuzik.Api.Configurations;
using Tmuzik.Api.Filters;
using Tmuzik.Api.Middlewares;
using Tmuzik.Api.SignalR;
using Tmuzik.Core;
using Tmuzik.Infrastructure.Data;

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
            services.AddCors(options => options.AddPolicy(DefaultPolicy, builder =>
            {
                builder
                    .WithOrigins(Configuration["Url:CorsOrigins"].Split(','))
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));

            services
                .AddControllers(options =>
                {
                    options.Filters.Add<ExceptionFilter>();
                    // options.Filters.Add<ResultFilter>();
                }).AddJsonOptions(options => {
                    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                }).AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<DummyDto>();
                    options.DisableDataAnnotationsValidation = true;
                });

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Configuration["ConnectionStrings:Default"]));

            services.AddAutoMapper(typeof(DummyDto).Assembly);

            services.AddHttpContextAccessor();

            services.AddAutoServiceResolvers();

            services.AddApplicationServices();

            services.AddDataRepositories();

            services.AddHttpClient();

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

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseRouting();

            app.UseJwtAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}
