using System;

namespace Cores.CoreExtensions
{
    public static partial class Extensions
    {
        public static T xClone<T>(this T obj) where T : class, new()
        {
            T clone = new T(); 
            foreach (var property in obj.GetType().GetProperties())
            {
                var propertyValue = property.GetValue(property.Name);
                var clonePropertyInfo = clone.GetType().GetProperty(property.Name);
                clonePropertyInfo.SetValue(clone, Convert.ChangeType(propertyValue, clonePropertyInfo.PropertyType), null);
            }
            return clone;
        }
    }
}
