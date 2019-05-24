using EmployeesManager.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace EmployeesManager.Infrastructure.Service
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IEmployeeService _employeeService;

        public DataInitializer(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async void SeedData()
        {
            var employees = await _employeeService.BrowseAsync();
            if (employees.Any())
                return;

            await _employeeService.AddEmployeeAsync(new EmployeeDto
            {
                Id = Guid.NewGuid(),
                BirthDate = DateTime.ParseExact("1964-02-06", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                FirstName = "Andrzej",
                LastName = "Wajda",
                NIP = "9714303042",
                Position = "Reżyser",
                Salary = 150000
            });

            await _employeeService.AddEmployeeAsync(new EmployeeDto
            {
                Id = Guid.NewGuid(),
                BirthDate = DateTime.ParseExact("1164-12-11", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                FirstName = "Władysław",
                LastName = "Jagiełło",
                NIP = "9714303042",
                Position = "Krów",
                Salary = 644360000
            });

            await _employeeService.AddEmployeeAsync(new EmployeeDto
            {
                Id = Guid.NewGuid(),
                BirthDate = DateTime.ParseExact("1924-12-26", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                FirstName = "Henryk",
                LastName = "Sienkiewicz",
                NIP = "7614203848",
                Position = "Pisarz",
                Salary = 230000
            });

            await _employeeService.AddEmployeeAsync(new EmployeeDto
            {
                Id = Guid.NewGuid(),
                BirthDate = DateTime.ParseExact("1214-02-06", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                FirstName = "Adam",
                LastName = "Mickiewicz",
                NIP = "1191046053",
                Position = "Poeta",
                Salary = 1100
            });
        }
    }
}
