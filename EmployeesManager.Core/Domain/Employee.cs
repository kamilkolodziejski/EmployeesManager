using EmployeesManager.Core.Domain;
using EmployeesManager.Infrastructure.IoC;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace EmployeesManager.Infrastructure.XmlRepository
{
    public class Employee
    {
        public Guid Id { get; protected set; }
        public string NIP { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; protected set; }
        public string Position { get; set; }
        public int Salary { get; protected set; }

        protected Employee()
        {
        }

        public Employee(Guid id, string nip, string firstName, string lastName, DateTime birthDate, string position, int salary)
        {
            Id = id;
            SetNIP(nip);
            FirstName = firstName;
            LastName = lastName;
            SetBirthDate(birthDate);
            Position = position;
            SetSalary(salary);
        }

        public void SetNIP(string nip)
        {
            if(!ValidateNIP(nip))
            {
                throw new EmployeeManagerException("NIP jest niepoprawny");
            }
            NIP = nip;
        }

        public void SetBirthDate(DateTime birthDate)
        {
            if(!birthDate.IsOfAge())
            {
                throw new EmployeeManagerException("Pracownik nie jest pełnoletni");
            }
            BirthDate = birthDate;
        }

        public void SetSalary(int salary)
        {
            if(salary<=0)
            {
                throw new EmployeeManagerException("Wynagrodzenie musi być większe od 0");
            }
            Salary = salary;
        }

        private bool ValidateNIP(String nip)
        {
            if(nip.Length!=10)
            {
                return false;
            }
            if(!nip.All(x => x>= '0' && x<= '9'))
            {
                return false;
            }

            int[] weights = new int[] { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
            var sum = weights.Zip(nip, (a, b) => a * (b - '0')).Sum();

            return (sum % 11) == (nip[9] - '0');
        }
    }
}
