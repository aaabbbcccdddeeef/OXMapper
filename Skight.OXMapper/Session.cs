using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Skight.OXMapper
{
    public class Session:IDisposable
    {
        private string path;
        private Dictionary<Type, Dictionary<Guid, object>> caches;
        public Session(string path)
        {
            this.path = path;
            caches=new Dictionary<Type, Dictionary<Guid, object>>();
        }

        public void save<T>(T obj)
        {
            var type = typeof (T);
            if(!caches.ContainsKey(type))  
                caches.Add(type,new Dictionary<Guid, object>());
            if(caches[type].ContainsKey(resolve(obj)))
                caches[type].Add(resolve(obj),obj);


        }
        private Guid resolve(object obj)
        {
            return Guid.Empty;
        }
        

        public void Dispose()
        {
            foreach (var type in caches)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                var writer = new StringWriter();
                    using (var xmlWriter =new XmlTextWriter(writer){Formatting = Formatting.Indented})
                    {
                        xmlWriter.WriteStartElement("MyClass");
                        xmlWriter.WriteStartElement("Guid");
                        xmlWriter.WriteValue(Guid.Empty.ToString());
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteStartElement("Name");
                        xmlWriter.WriteValue("WangHao");
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndElement();
        
                    }
            Console.Write(writer.ToString());
            
            }
        }
    }
}