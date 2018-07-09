using System;

namespace Cores.CoreUtilities
{
    public class ReturnObject
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Object { get; set; }
        public Exception Exception { get; set; }

        public ReturnObject()
        {

        }

        public ReturnObject(bool status, string message)
        {
            Status = status;
            Message = message;
        }

        public ReturnObject(bool status, string message, object obj)
        {
            Status = status;
            Message = message;
            Object = obj;
        }

        public ReturnObject(bool status, string message, Exception exception)
        {
            Status = status;
            Message = message;
            Exception = exception;
        }
    }
}
