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
    }
}
