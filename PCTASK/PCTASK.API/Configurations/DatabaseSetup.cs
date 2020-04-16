using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PCTASK.Data;

namespace PCTASK.API.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var connection = configuration.GetConnectionString("DefaultConnection");
            if (env.IsProduction())
            {
                var builder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"));
                builder.Password = configuration["DB_PASSWORD"];

                connection = builder.ConnectionString;
            }

            services.AddDbContext<ProductContext>(options =>
                options.UseSqlServer(connection));
        }
    }
}