using System;

namespace Core.Exceptions
{
    public class UnAuthorizedExceptions: Exception
    {
        public UnAuthorizedExceptions(string message): base(message)
        {
            
        }
    }

    public class InValidInputException : Exception
    {
        public InValidInputException(string message) : base(message)
        {

        }
    }
}
