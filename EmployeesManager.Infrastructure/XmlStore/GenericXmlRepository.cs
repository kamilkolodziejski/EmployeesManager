using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EmployeesManager.Infrastructure.XmlStore
{
    public abstract class GenericXmlStore<T>
    {
        protected readonly string _path;
        protected HashSet<T> _store;

        public GenericXmlStore(string path)
        {
            _path = path;
            Initialize();
        }

        private void Initialize()
        {
            if (File.Exists(_path))
            {
                using(FileStream fileStream = new FileStream(_path, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<T>));                    
                    _store = (HashSet<T>)xmlSerializer.Deserialize(fileStream);
                }
            }
            else
            {
                _store = new HashSet<T>();
            }
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<T>));
            using (TextWriter streamWriter = new StreamWriter(_path))
            {
                xmlSerializer.Serialize(streamWriter, _store);
            }
        }
    }
}
