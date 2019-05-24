using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EmployeesManager.Core.Domain
{
    public class EmployeeManagerException : Exception
    {
        public EmployeeManagerException()
        {
        }
        public EmployeeManagerException(string message) : base(message)
        {
        }
        public EmployeeManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected EmployeeManagerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
