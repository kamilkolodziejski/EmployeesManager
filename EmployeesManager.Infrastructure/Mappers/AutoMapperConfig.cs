using AutoMapper;
using EmployeesManager.Infrastructure.XmlStore;
using EmployeesManager.Infrastructure.Dto;
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
               cfg.CreateMap<Employee, EmployeeDto>();
               cfg.CreateMap<Employee, EmployeeXmlEntity>();
               cfg.CreateMap<EmployeeXmlEntity, Employee>();

           }).CreateMapper();
    }
}
