using System;

namespace Skight.OXMapper.Mapping
{
    public class XMLMap<T>
    {
        protected void Id(Func<T, object> memberExpression)
        {
            throw new NotImplementedException();
        }

        protected void Map(Func<T, object> memberExpression)
        {
            throw new NotImplementedException();
        }
    }
}