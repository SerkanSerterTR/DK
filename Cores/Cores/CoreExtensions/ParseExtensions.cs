using System;

namespace Cores.CoreExtensions
{
    public static partial class Extensions
    {
        public static TResult xParse<T,TResult>(this T value) where T : struct
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
