using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PCTASK.Domain.AutoMapper;

namespace PCTASK.API.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelProfile), typeof(ViewModelToDomainProfile));
        }

    }
}