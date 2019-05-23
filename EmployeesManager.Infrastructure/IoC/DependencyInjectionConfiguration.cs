﻿using System;
using Microsoft.Extensions.DependencyInjection;
using EmployeesManager.Infrastructure.Mappers;
using EmployeesManager.Infrastructure.XmlStore;
using EmployeesManager.Infrastructure.Service;

namespace EmployeesManager.Infrastructure.IoC
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton(AutoMapperConfig.Initalize());

            services.AddSingleton<IEmployeeRepository, EmployeeXmlRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
