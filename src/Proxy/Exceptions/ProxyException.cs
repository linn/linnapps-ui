namespace Linn.LinnappsUi.Proxy.Exceptions
{
    using System;

    public class ProxyException : Exception
    {
        public ProxyException(string message)
            : base(message)
        {
        }

        public ProxyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
