using EmployeesManager.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EmployeesManager.Infrastructure.XmlDataStore
{
    public class EmployeeStore : IEmployeesXmlStore
    {
        ISet<Employee> Employees { get; }
        private readonly string _path = "Employees.xml";

        public EmployeeStore()
        {
            if (File.Exists(_path))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<Employee>));
                FileStream fileStream = new FileStream(_path, FileMode.OpenOrCreate);
                Employees = (HashSet<Employee>)xmlSerializer.Deserialize(fileStream);
            }
            else
            {
                Employees = new HashSet<Employee>();
            }
        }
        ISet<Employee> IEmployeesXmlStore.Employees => Employees;

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<Employee>));
            TextWriter streamWriter = new StreamWriter(_path);
            xmlSerializer.Serialize(streamWriter, Employees);
            streamWriter.Close();
        }
    }
}
