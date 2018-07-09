using System;

namespace Cores.CoreExtensions
{
    public static partial class Extensions
    {
        /// <summary>
        /// Değeri istenilen yapı türüne dönüştürür
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TResult xParse<T, TResult>(this T value)
            where T : struct
            where TResult : struct
        {
            try
            {
                return (TResult)Convert.ChangeType(value, typeof(TResult));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
