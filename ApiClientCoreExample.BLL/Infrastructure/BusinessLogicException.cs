using System;

namespace ApiClientCoreExample.BLL.Infrastructure
{
    public class BusinessLogicException : Exception
    {
        public string Property { get; protected set; }
        public BusinessLogicException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
