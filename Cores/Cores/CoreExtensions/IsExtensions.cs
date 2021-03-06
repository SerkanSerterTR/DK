﻿using System.Collections.Generic;

namespace Cores.CoreExtensions
{
    public static partial class Extensions
    {
        /// <summary>
        /// Nesnenin 'null' değer olup olmadığını döner. 
        /// Değer 'null' ise 'true', değil ise 'false' döner.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public static bool IsNull(this object obj)
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
        public static bool IsNotNull(this object obj)
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
        public static bool IsNumeric(this string value)
        {
            float output;
            return float.TryParse(value, out output);
        }

        /// <summary>
        /// String değerin tamsayı yapında olup olmadığnı döner.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInteger(this string value)
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
        public static bool HasValue<T>(this List<T> list)
        {
            return (list == null) ? false : list.Count > 0;
        }

        /// <summary>
        /// Array üzerinde elaman olup olmadığını döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns>bool</returns>
        public static bool HasValue<T>(this T[] array)
        {
            return (array == null) ? false : array.Length > 0;
        }

        /// <summary>
        /// Verilen değerin eşitliğini kontrol eder.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="main"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsEqual<T>(this T main, T target) where T : struct
        {
            return EqualityComparer<T>.Default.Equals(main, target);
        }

        /// <summary>
        /// Verilen değerin eşitliğini kontrol eder.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="main"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsNotEqual<T>(this T main, T target) where T : struct
        {
            return !EqualityComparer<T>.Default.Equals(main, target);
        }

    }
}
