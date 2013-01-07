using System.IO;

namespace Skight.OXMapper
{
    public class Session
    {
        private string path;

        public Session(string path)
        {
            this.path = path;
        }

        public void save<T>(T obj)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            using (var writer=new StreamWriter(new FileStream(path+ "/"+typeof(T).Name + ".xml",FileMode.Append)))
                {
                    
                
            writer.Write(@"<MyClass>
<Guid>
</Guid>
<Name>
WangHao
</Name>
</MyClass>");
        }
        }
    }
}