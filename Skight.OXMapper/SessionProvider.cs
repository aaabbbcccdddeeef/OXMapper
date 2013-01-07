namespace Skight.OXMapper
{
    public class SessionFactory
    {
        private string path;
        public SessionFactory(string path)
        {
            this.path = path;
        }

        public Session GetCurrentSession()
        {
            return new Session(path);
        }
    }
}