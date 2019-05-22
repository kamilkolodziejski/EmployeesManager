using AutoMapper;
using EmployeesManager.Infrastructure.XmlStore;
using EmployeesManager.Infrastructure.Service;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EmployeesManager.Tests
{
    public class EmployeeServiceTests
    {

        [Fact]
        public async void when_adding_employee_with_wrong_nip_should_throw_exception()
        {
            //var employee = new Employee(Guid.NewGuid(), "12345", "Jan", "Kowalski", new DateTime(1990, 1, 1), "Kierownik", 1500);
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                                    .ReturnsAsync(It.IsAny<Employee>());
            var mapperMock = new Mock<IMapper>();

            var employeeService = new EmployeeService(employeeRepositoryMock.Object, mapperMock.Object);
            //await employeeService.AddEmployeeAsync("213", "asad", "dsad", "1999-09-09", "Dwads", 432);

            var exc = await Assert.ThrowsAsync<ArgumentException>(() => employeeService.AddEmployeeAsync("213", "asad", "dsad", new DateTime(1985, 3, 1), "Dwads", 432));
            Assert.Equal("NIP jest niepoprawny", exc.Message);
        }

        [Fact]
        public async Task when_adding_new_employee_should_invoke_user_repository_add_asyncAsync()
        {
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                                        .ReturnsAsync(It.IsAny<Employee>());
            var mapperMock = new Mock<IMapper>();

            var employeeService = new EmployeeService(employeeRepositoryMock.Object, mapperMock.Object);
            await employeeService.AddEmployeeAsync("5234736750", "adam", "nowak", new DateTime(1975,3,11), "sprz¹taczka", 25000);

            employeeRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Employee>()), Times.Once);
        }

        [Fact]
        public async void when_updating_employe_should_invoke_user_repository_update_async()
        {
            var employee = new Employee(Guid.NewGuid(), "5234736750", "Jan", "Kowalski", new DateTime(1990, 1, 1), "Kierownik", 1500);
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            var mapperMock = new Mock<IMapper>();
            employeeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                                        .ReturnsAsync(employee);

            var employeeService = new EmployeeService(employeeRepositoryMock.Object, mapperMock.Object);
            await employeeService.UpdateEmployeeAsync(Guid.NewGuid(),"dsadw","dwads","dwafa", new DateTime(1979, 9, 22), "dwads",23421);

            employeeRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Employee>()), Times.Once);
        }

        [Fact]
        public async void when_deleting_employee_should_invoke_user_repository_remove_async()
        {
            //var employee = new Employee(Guid.NewGuid(), "12345", "Jan", "Kowalski", new DateTime(1990, 1, 1), "Kierownik", 1500);
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            var mapperMock = new Mock<IMapper>();
            employeeRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                                        .ReturnsAsync(It.IsAny<Employee>);

            var employeeService = new EmployeeService(employeeRepositoryMock.Object, mapperMock.Object);

            await employeeService.DeleteEmployeeAsync(It.IsAny<Guid>());

            employeeRepositoryMock.Verify(x => x.RemoveAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}
