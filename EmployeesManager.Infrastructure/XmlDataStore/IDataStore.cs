using EmployeesManager.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Infrastructure.XmlDataStore
{
    public interface IDataStore
    {
        void Save();
    }
}
