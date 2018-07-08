using System;

namespace Cores.CoreExtensions
{
    public static class IsExtensions
    {
        public static bool xIsNull(this object obj)
        {
            if (obj == null) return true;
            if (obj.GetType() == typeof(string))
                if (string.IsNullOrWhiteSpace(obj as string)) return true;
            return false;
        }

        public static bool xIsNotNull(this object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() == typeof(string))
                if (string.IsNullOrWhiteSpace(obj as string)) return false;
            return true;
        }

        public static bool xIsNumeric(this string value)
        {
            float output;
            return float.TryParse(value, out output);
        }

        public static bool xIsInteger(this string value)
        {
            int output;
            return int.TryParse(value, out output);
        }
    }
}
