using AutoMapper;
using EmployeesManager.Infrastructure.XmlRepository;
using EmployeesManager.Infrastructure.Service;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using EmployeesManager.Infrastructure.Dto;
using EmployeesManager.Core.Domain;

namespace EmployeesManager.Tests
{
    public class EmployeeServiceTests
    {
        [Fact]
        public async Task when_adding_new_employee_should_invoke_user_repository_add_async()
        {
            var employee = new Employee(Guid.NewGuid(), "5720722356", "Jan", "Kowalski", new DateTime(1990, 1, 1), "Kierownik", 1500);
            var employeeDto = new EmployeeDto(employee.Id, employee.NIP, employee.FirstName, employee.LastName,
                                            employee.BirthDate, employee.Position, employee.Salary);

            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            //employeeRepositoryMock.Setup(x => x.AddAsync(employee));
            var mapperMock = new Mock<IMapper>();


            IEmployeeService employeeService = new EmployeeService(employeeRepositoryMock.Object, mapperMock.Object);
            await employeeService.AddEmployeeAsync(employeeDto);

            employeeRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Employee>()), Times.Once);
        }

        [Fact]
        public async void when_updating_employee_should_invoke_user_repository_update_async()
        {
            var employee = new Employee(Guid.NewGuid(), "5720722356", "Jan", "Kowalski", new DateTime(1990, 1, 1), "Kierownik", 1500);
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(x => x.GetAsync(employee.Id))
                                        .ReturnsAsync(employee);
            //employeeRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Employee>()));
            var mapperMock = new Mock<IMapper>();
            //mapperMock.Setup(x => x.Map<Employee, EmployeeXmlEntity>(It.IsAny<Employee>()))
            //                    .Returns(It.IsAny<EmployeeXmlEntity>());

            IEmployeeService employeeService = new EmployeeService(employeeRepositoryMock.Object, mapperMock.Object);
            var employeeDto = new EmployeeDto(employee.Id, employee.NIP, employee.FirstName, employee.LastName, 
                                                employee.BirthDate, employee.Position, employee.Salary);
            await employeeService.UpdateEmployeeAsync(employeeDto);

            employeeRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Employee>()), Times.Once);
        }

        [Fact]
        public async void when_deleting_employee_should_invoke_user_repository_remove_async()
        {
            var employee = new Employee(Guid.NewGuid(), "5720722356", "Jan", "Kowalski", new DateTime(1990, 1, 1), "Kierownik", 1500);
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            var mapperMock = new Mock<IMapper>();
            employeeRepositoryMock.Setup(x => x.GetAsync(employee.Id))
                                        .ReturnsAsync(employee);

            IEmployeeService employeeService = new EmployeeService(employeeRepositoryMock.Object, mapperMock.Object);

            await employeeService.DeleteEmployeeAsync(employee.Id);

            employeeRepositoryMock.Verify(x => x.RemoveAsync(employee), Times.Once);
        }
    }
}
