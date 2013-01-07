namespace Skight.OXMapper
{
    public class Configuration
    {
        private string path;
        public Configuration Path(string path)
        {
            this.path = path;
            return this;
        }

        public Configuration Register<T>()
        {
            return this;
        }

        public SessionFactory BuildSessionFactory()
        {
            return new SessionFactory(path);
        }
    }
}