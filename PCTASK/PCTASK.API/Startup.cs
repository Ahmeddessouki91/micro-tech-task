using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PCTASK.API.Configurations;
using PCTASK.Data;
using PCTASK.Data.Interfaces;
using PCTASK.Data.Services;
using PCTASK.Domain.Interfaces;
using PCTASK.Domain.Services;

namespace PCTASK.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IHostEnvironment env;
        public Startup(IHostEnvironment env)
        {
            this.env = env;
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", true, true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // AutoMapper Setup
            services.AddAutoMapperSetup();

            //DB Context Setup
            services.AddDatabaseSetup(Configuration, env);

            // Swagger Config
            services.AddSwaggerSetup();

            // Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ProductContext>();

            // Domain
            services.AddScoped<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c =>
                       {
                           c.AllowAnyHeader();
                           c.AllowAnyMethod();
                           c.AllowAnyOrigin();
                       });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();
        }
    }
}
