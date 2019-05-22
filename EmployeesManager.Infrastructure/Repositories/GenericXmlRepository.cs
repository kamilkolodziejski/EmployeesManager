using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EmployeesManager.Infrastructure.Repositories
{
    public class GenericXmlRepository<T>
    {
        protected readonly string _path;
        protected HashSet<T> _store;

        public GenericXmlRepository(string path)
        {
            _path = path;
        }

        private void Load()
        {
            if (File.Exists(_path))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<T>));
                FileStream fileStream = new FileStream(_path, FileMode.OpenOrCreate);
                _store = (HashSet<T>)xmlSerializer.Deserialize(fileStream);
            }
            else
            {
                _store = new HashSet<T>();
            }
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<T>));
            TextWriter streamWriter = new StreamWriter(_path);
            xmlSerializer.Serialize(streamWriter, _store);
            streamWriter.Close();
        }
    }
}
