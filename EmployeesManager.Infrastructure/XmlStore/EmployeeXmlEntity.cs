using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Infrastructure.XmlStore
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
    }
}
