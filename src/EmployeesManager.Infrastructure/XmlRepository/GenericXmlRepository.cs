using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EmployeesManager.Infrastructure.XmlRepository
{
    public abstract class GenericXmRepository<T, T1>
    {
        protected readonly string _path;
        protected HashSet<T> _store;

        public GenericXmRepository(string path)
        {
            _path = path;
            Initialize();
        }

        protected abstract HashSet<T> Restore(HashSet<T1> t1);
        protected abstract HashSet<T1> Persist(HashSet<T> t);

        private void Initialize()
        {
            if (File.Exists(_path))
            {
                using(FileStream fileStream = new FileStream(_path, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<T1>));
                    HashSet<T1> t1 = (HashSet<T1>)xmlSerializer.Deserialize(fileStream);
                    _store = Restore(t1);
                }
            }
            else
            {
                _store = new HashSet<T>();
            }
        }

        protected void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<T1>));
            using (TextWriter streamWriter = new StreamWriter(_path))
            {
                HashSet<T1> t1 = Persist(_store);
                xmlSerializer.Serialize(streamWriter, t1);
            }
        }
    }
}
