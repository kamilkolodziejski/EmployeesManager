using EmployeesManager.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EmployeesManager.Infrastructure.XmlDataStore
{
    public class EmployeeXmlStore : GenerociXmlStore<Employee>, IEmployeesStore
    {
        public ISet<Employee> Employees => base.store;

        public EmployeeXmlStore() : base("D:\\EmployeeDb.xml")
        {
        }
    }
}
