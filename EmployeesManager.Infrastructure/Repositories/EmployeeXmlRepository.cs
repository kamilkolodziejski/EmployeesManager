using AutoMapper;
using EmployeesManager.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManager.Infrastructure.XmlStore
{
    public class EmployeeXmlRepository : GenericXmlStore<EmployeeXmlEntity>, IEmployeeRepository
    {
        private readonly IMapper _mapper;
        private readonly IOptions<XmlRepositorySettings> _settings;
        public EmployeeXmlRepository(IMapper mapper, IOptions<XmlRepositorySettings> settings) : base(settings.Value.EmployeeXmlPath)
        {
            _mapper = mapper;
            _settings = settings;
        }

        public async Task AddAsync(Employee employee)
        {
            _store.Add(_mapper.Map<EmployeeXmlEntity>(employee));
            Save();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Employee>> BrowseAsync()
            => await Task.FromResult(_mapper.Map<IEnumerable<Employee>>(_store));

        public async Task<Employee> GetAsync(string NIP)
            => await Task.FromResult(_mapper.Map<Employee>(_store.Where(x => x.NIP == NIP).SingleOrDefault()));

        public async Task<Employee> GetAsync(Guid id)
            => await Task.FromResult(_mapper.Map<Employee>(_store.Where(x => x.Id == id).SingleOrDefault()));

        public async Task RemoveAsync(Guid id)
        {
            var employee = _store.SingleOrDefault(x => x.Id == id);
            _store.Remove(employee);
            Save();
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Employee employee)
        {
            var employeeFromStore = _store.SingleOrDefault(x => x.Id == employee.Id);
            employeeFromStore.FirstName = employee.FirstName;
            employeeFromStore.LastName = employee.LastName;
            employeeFromStore.BirthDate = employee.BirthDate;
            employeeFromStore.Position = employee.Position;
            employeeFromStore.Salary = employee.Salary;
            Save();
            await Task.CompletedTask;
        }
    }
}
