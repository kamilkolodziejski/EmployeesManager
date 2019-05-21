using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Core.Model
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string NIP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }

        protected Employee()
        {
        }

        public Employee(Guid id, string nIP, string firstName, string lastName, DateTime birthDate, string position, int salary)
        {
            Id = id;
            NIP = nIP;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Position = position;
            Salary = salary;
        }
    }
}
