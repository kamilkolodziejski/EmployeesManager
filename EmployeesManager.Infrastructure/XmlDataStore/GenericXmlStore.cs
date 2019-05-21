using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EmployeesManager.Infrastructure.XmlDataStore
{
    public abstract class GenerociXmlStore<T> 
    {
        protected HashSet<T> store;
        protected readonly string _path;

        public GenerociXmlStore(string path)
        {
            _path = path;
        }

        public void Load()
        {
            if (File.Exists(_path))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<T>));
                FileStream fileStream = new FileStream(_path, FileMode.OpenOrCreate);
                store = (HashSet<T>)xmlSerializer.Deserialize(fileStream);
            }
            else
            {
                store = new HashSet<T>();
            }
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<T>));
            TextWriter streamWriter = new StreamWriter(_path);
            xmlSerializer.Serialize(streamWriter, store);
            streamWriter.Close();
        }
    }
}
