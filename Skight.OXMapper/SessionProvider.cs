namespace Skight.OXMapper
{
    public class SessionProvider
    {
        public static SessionProvider Instance
        {
            get { return new SessionProvider();}
        }

        public Session CurrentSession { get; private set; }
    }
}