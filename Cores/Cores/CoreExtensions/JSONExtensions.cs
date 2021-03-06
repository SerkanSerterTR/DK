﻿namespace Cores.CoreExtensions
{
    public static partial class Extensions
    {
        /// <summary>
        /// Verilen nesneyi JSON string formatına dönüştürür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>string</returns>
        public static string ToJSONString<T>(this T obj) where T : class
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// JSON string yapıdaki değeri istenilen sınıf tipinde nesneye dönüştürür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns>T</returns>
        public static T JSONtoObject<T>(this string jsonString) where T : class
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
