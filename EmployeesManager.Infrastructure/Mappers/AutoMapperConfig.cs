using AutoMapper;
using EmployeesManager.Core.Model;
using EmployeesManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initalize()
            => new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Employee, EmployeeDTO>();

           }).CreateMapper();
    }
}
