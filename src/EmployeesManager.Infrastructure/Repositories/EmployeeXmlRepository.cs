using AutoMapper;
using EmployeesManager.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManager.Infrastructure.XmlRepository
{
    public class EmployeeXmlRepository : GenericXmRepository<Employee, EmployeeXmlEntity>, IEmployeeRepository
    {
        private readonly IMapper _mapper;
        public EmployeeXmlRepository(IMapper mapper, IOptions<XmlRepositorySettings> settings) : base(settings.Value.EmployeeXmlPath)
        {
            _mapper = mapper;
        }

        public async Task AddAsync(Employee employee)
        {
            _store.Add(employee);
            Save();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
            => await Task.FromResult(_store.ToList());

        public async Task<Employee> GetAsync(Guid id)
            => await Task.FromResult(_store.SingleOrDefault(x => x.Id == id));

        public async Task RemoveAsync(Employee employee)
        {
            _store.Remove(employee);
            Save();
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Employee employee)
        {
            var employeeFromStore = _store.SingleOrDefault(x => x.Id == employee.Id);
            if(employeeFromStore != null)
            {
                employeeFromStore = employee;
                Save();
            }
            await Task.CompletedTask;
        }

        protected override HashSet<EmployeeXmlEntity> Persist(HashSet<Employee> t)
            => _mapper.Map<ISet<Employee>, HashSet<EmployeeXmlEntity>>(t);

        protected override HashSet<Employee> Restore(HashSet<EmployeeXmlEntity> t1)
            => t1.Select(x => x.GetEmployee()).ToHashSet();
    }
}
