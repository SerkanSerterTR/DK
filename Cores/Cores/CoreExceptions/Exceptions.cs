using System;

namespace Cores.CoreExceptions
{
    public static class Exceptions
    {
        /// <summary>
        /// Gönderilen metotda Exception varsa Exception fırlatır.
        /// </summary>
        /// <param name="method"></param>
        public static void ThrowException(Action method)
        {
            try
            {
                method.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gönderilen metotda Exception varsa Exception fırlatır.
        /// </summary>
        /// <param name="method"></param>
        public static void ThrowException<T>(Func<T> method)
        {
            try
            {
                method.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gönderilen metotda Exception varsa Exception metotunu çalıştırır ve Exception fırlatır.
        /// </summary>
        /// <param name="method"></param>
        public static object ThrowException<T>(Func<T> method, Func<Exception, object> exceptionMethod)
        {
            try
            {
                return method.Invoke();
            }
            catch (Exception ex)
            {
                return exceptionMethod.Invoke(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Gönderilen metotda Exception varsa Exception metotunu çalıştırır ve Exception fırlatır.
        /// </summary>
        /// <param name="method"></param>
        public static void ThrowException(Action method, Func<Exception, object> exceptionMethod)
        {
            try
            {
                method.Invoke();
            }
            catch (Exception ex)
            {
                exceptionMethod.Invoke(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Gönderilen metotda Exception varsa Exception metotunu çalıştırır.
        /// </summary>
        /// <param name="method"></param>
        public static object Exception<T>(Func<T> method, Func<Exception, object> exceptionMethod)
        {
            try
            {
                return method.Invoke();
            }
            catch (Exception ex)
            {
                return exceptionMethod.Invoke(ex);
            }
        }

        /// <summary>
        /// Gönderilen metotda Exception varsa Exception metotunu çalıştırır.
        /// </summary>
        /// <param name="method"></param>
        public static void Exception(Action method, Func<Exception, object> exceptionMethod)
        {
            try
            {
                method.Invoke();
            }
            catch (Exception ex)
            {
                exceptionMethod.Invoke(ex);
            }
        }

        /// <summary>
        /// Gönderilen metotda Exception varsa Exception metotunu çalıştırır.
        /// </summary>
        /// <param name="method"></param>
        public static void ExceptionVoid(Action method, Action<Exception> exceptionMethod)
        {
            try
            {
                method.Invoke();
            }
            catch (Exception ex)
            {
                exceptionMethod.Invoke(ex);
            }
        }
    }
}