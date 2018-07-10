using System;
using System.Reflection;

namespace Cores.CoreExtensions
{
    public static partial class Extensions
    {
        /// <summary>
        /// Nesnenin kopyasını döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T Clone<T>(this T obj) where T : class, new()
        {
            T clone = new T();
            foreach (var property in obj.GetType().GetProperties())
            {
                var propertyValue = property.GetValue(property.Name);
                var clonePropertyInfo = clone.GetType().GetProperty(property.Name);
                if (clonePropertyInfo != null)
                    clonePropertyInfo.SetValue(clone, Convert.ChangeType(propertyValue, clonePropertyInfo.PropertyType), null);
            }
            return clone;
        }

        /// <summary>
        /// Nesnenin alan değerlerinin aynı sınıftan başka bir nesneye aktarılmasını sağlar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mainObject"></param>
        /// <returns></returns>
        public static void CopyProperties<T>(this T mainObject, ref T targetObject)
            where T : class, new()
        {
            foreach (var property in mainObject.GetType().GetProperties())
            {
                var propertyValue = property.GetValue(property.Name);
                var targetPropertyInfo = targetObject.GetType().GetProperty(property.Name);
                if (targetPropertyInfo != null)
                    targetPropertyInfo.SetValue(targetObject, Convert.ChangeType(propertyValue, targetPropertyInfo.PropertyType), null);
            } 
        }

        /// <summary>
        /// Nesnenin alan değerlerinin farklı sınıftan başka bir nesneye aktarılmasını sağlar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mainObject"></param>
        /// <returns></returns>
        public static void CopyProperties<TMain, TTarget>(this TMain mainObject, ref TTarget targetObject)
            where TMain : class, new()
            where TTarget : class, new()
        {
            foreach (var property in mainObject.GetType().GetProperties())
            {
                var propertyValue = property.GetValue(property.Name);
                var targetPropertyInfo = targetObject.GetType().GetProperty(property.Name);
                if (targetPropertyInfo != null)
                    targetPropertyInfo.SetValue(targetObject, Convert.ChangeType(propertyValue, targetPropertyInfo.PropertyType), null);
            } 
        }

        /// <summary>
        /// Nesnenin alan değerlerinin aynı sınıftan başka bir nesne ile karşılaştırmasını yapar.
        /// Tüm alan değerlernin eşit-aynı olaması beklenir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mainObject"></param>
        /// <returns></returns>
        public static bool CompareProperties<T>(this T mainObject, T targetObject)
            where T : class, new()
        {
            foreach (var property in mainObject.GetType().GetProperties())
            {
                var propertyValue = property.GetValue(property.Name);
                PropertyInfo targetPropertyInfo = targetObject.GetType().GetProperty(property.Name);
                if (targetPropertyInfo != null)
                    if (propertyValue != targetPropertyInfo.GetValue(targetObject))
                        return false;
            }
            return true;
        }

        /// <summary>
        /// Nesnenin alan değerlerinin farklı sınıftan başka bir nesne ile karşılaştırmasını yapar.
        /// Tüm alan değerlernin eşit-aynı olaması beklenir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mainObject"></param>
        /// <returns></returns>
        public static bool CompareProperties<TMain, TTarget>(this TMain mainObject, TTarget targetObject)
            where TMain : class, new()
            where TTarget : class, new()
        {
            foreach (var property in mainObject.GetType().GetProperties())
            {
                var propertyValue = property.GetValue(property.Name);
                PropertyInfo targetPropertyInfo = targetObject.GetType().GetProperty(property.Name);
                if (targetPropertyInfo != null)
                    if (propertyValue != targetPropertyInfo.GetValue(targetObject))
                        return false;
            }
            return true;
        }
    }
}
