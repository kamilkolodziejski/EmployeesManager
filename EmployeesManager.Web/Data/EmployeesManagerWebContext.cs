using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeesManager.Infrastructure.Dto;

namespace EmployeesManager.Web.Models
{
    public class EmployeesManagerWebContext : DbContext
    {
        public EmployeesManagerWebContext (DbContextOptions<EmployeesManagerWebContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeesManager.Infrastructure.Dto.EmployeeDto> EmployeeDto { get; set; }
    }
}
