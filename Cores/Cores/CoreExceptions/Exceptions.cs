using System;

namespace Cores.CoreExceptions
{
    public static class Exceptions
    {
        /// <summary>
        /// Gönderilen metotda Exception varsa Exception fırlatır.
        /// </summary>
        /// <param name="func"></param>
        public static void ThrowException(Action func)
        {
            try
            {
                func.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gönderilen metotda Exception varsa Exception fırlatır.
        /// </summary>
        /// <param name="func"></param>
        public static void ThrowException<T>(Func<T> func)
        {
            try
            {
                func.Invoke();
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
        public static object ThrowExceptionWithLog<T>(Func<T> func, Func<Exception, object> logFunc)
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
        /// Gönderilen metotda Exception varsa log metotunu çalıştırır ve Exception fırlatır.
        /// </summary>
        /// <param name="func"></param>
        public static void ThrowExceptionWithLog(Action func, Func<Exception, object> logFunc)
        {
            try
            {
                func.Invoke();
            }
            catch (Exception ex)
            {
                logFunc.Invoke(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Gönderilen metotda Exception varsa log metotunu çalıştırır.
        /// </summary>
        /// <param name="func"></param>
        public static object ExceptionWithLog<T>(Func<T> func, Func<Exception, object> logFunc)
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

        /// <summary>
        /// Gönderilen metotda Exception varsa log metotunu çalıştırır.
        /// </summary>
        /// <param name="func"></param>
        public static void ExceptionWithLog(Action func, Func<Exception, object> logFunc)
        {
            try
            {
                func.Invoke();
            }
            catch (Exception ex)
            {
                logFunc.Invoke(ex);
            }
        }

        /// <summary>
        /// Gönderilen metotda Exception varsa log metotunu çalıştırır.
        /// </summary>
        /// <param name="func"></param>
        public static void ExceptionWithVoidLog(Action func, Action<Exception> logFuncVoid)
        {
            try
            {
                func.Invoke();
            }
            catch (Exception ex)
            {
                logFuncVoid.Invoke(ex);
            }
        }
    }
}