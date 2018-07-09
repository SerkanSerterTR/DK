using System;
using System.Collections.Generic;

namespace Cores.CoreExtensions
{
    public static class IsExtensions
    {
        /// <summary>
        /// Nesnenin 'null' değer olup olmadığını döner. 
        /// Değer 'null' ise 'true', değil ise 'false' döner.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public static bool xIsNull(this object obj)
        {
            if (obj == null) return true;
            if (obj.GetType() == typeof(string))
                if (string.IsNullOrWhiteSpace(obj as string)) return true;
            return false;
        }

        /// <summary>
        /// Nesnenin 'null' değer olup olmadığını döner. 
        /// Değer 'null' ise 'false', değil ise 'true' döner.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        /// 
        public static bool xIsNotNull(this object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() == typeof(string))
                if (string.IsNullOrWhiteSpace(obj as string)) return false;
            return true;
        }

        /// <summary>
        /// String değerin sayısal yapında olup olmadığnı döner.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>bool</returns>
        public static bool xIsNumeric(this string value)
        {
            float output;
            return float.TryParse(value, out output);
        }

        /// <summary>
        /// String değerin tamsayı yapında olup olmadığnı döner.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool xIsInteger(this string value)
        {
            int output;
            return int.TryParse(value, out output);
        }

        /// <summary>
        /// List üzerinde elaman olup olmadığını döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns>bool</returns>
        public static bool xHasValue<T>(this List<T> list)
        {
            if (list.Count > 0) return true;
            return false;
        }

        /// <summary>
        /// Array üzerinde elaman olup olmadığını döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns>bool</returns>
        public static bool xHasValue<T>(this T[] array)
        {
            if (array.Length > 0) return true;
            return false;
        }
    }
}
