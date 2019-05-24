using EmployeesManager.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Infrastructure.IoC
{
    public static class SettingsConfiguration
    {
        public static void ConfigureSettings(this IServiceCollection services, 
                                                            IConfiguration configuration)
        {
            var xmlRepositorySection = configuration.GetSection("XmlRepositorySettings");

            services.Configure<XmlRepositorySettings>(x => xmlRepositorySection.Bind(x));
        }
    }
}
