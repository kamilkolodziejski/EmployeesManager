using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeesManager.Infrastructure.Dto
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        [RegularExpression("([0-9]{10})",ErrorMessage ="NIP powinien składać się z 10 cyfr")]
        public string NIP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public EmployeeDto()
        {
        }
        public EmployeeDto(Guid id, string nIP, string firstName, string lastName, DateTime birthDate, string position, int salary)
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
