using System;

namespace Cores.CoreExceptions
{
    public static class Exceptions
    {
        /// <summary>
        /// Gönderilen metotda Exception varsa Exception fırlatır.
        /// </summary>
        /// <param name="func"></param>
        public static object ThrowException(Func<object> func)
        {
            try
            {
                return func.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Gönderilen metotda Exception varsa log metotunu çalıştırır ve Exception fırlatır.
        /// </summary>
        /// <param name="func"></param>
        public static object ThrowExceptionWithLog(Func<object> func, Func<Exception, object> logFunc)
        {
            try
            {
                return func.Invoke();
            }
            catch (Exception ex)
            {
                return logFunc.Invoke(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Gönderilen metotda Exception varsa log metotunu çalıştırır.
        /// </summary>
        /// <param name="func"></param>
        public static object ExceptionWithLog(Func<object> func, Func<Exception, object> logFunc)
        {
            try
            {
                return func.Invoke();
            }
            catch (Exception ex)
            {
                return logFunc.Invoke(ex);
            }
        }
    }
}