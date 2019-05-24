using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Infrastructure.XmlRepository
{
    public class EmployeeXmlEntity
    {
        public Guid Id { get; set; }
        public string NIP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }

        public EmployeeXmlEntity()
        {
        }

        public EmployeeXmlEntity(Guid id, string nip, string firstName, string lastName, DateTime birthDate, string position, int salary)
        {
            Id = id;
            NIP = nip;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Position = position;
            Salary = salary;
        }

        public Employee GetEmployee()
            => new Employee(Id, NIP, FirstName, LastName, BirthDate, Position, Salary);
    }
}
