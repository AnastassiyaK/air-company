using System;

namespace Aircompany.Exceptions
{
    public class PlanesNoFoundException : Exception
    {
        public PlanesNoFoundException(string message)
            : base($"{message} Airport does not contain any planes")
        {
        }
    }
}
