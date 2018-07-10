using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cores.CoreExtensions
{
    public static partial class Extensions
    {
        /// <summary>
        /// CultureInfo nesnesi ile string değerdeki tüm harfleri büyütür.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cultereinfo"></param>
        /// <returns></returns>
        public static string ToUpper(this string text, string cultereinfo = "tr-TR")
        {
            return text.ToUpper(new System.Globalization.CultureInfo(cultereinfo));
        }

        /// <summary>
        ///  CultureInfo nesnesi ile string değerdeki tüm harfleri küçültür.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cultereinfo"></param>
        /// <returns></returns>
        public static string ToLower(this string text, string cultereinfo = "tr-TR")
        {
            return text.ToLower(new System.Globalization.CultureInfo(cultereinfo));
        }

        /// <summary>
        /// CultureInfo nesnesi ile string değerdeki ilk harfini büyük diğerleri küçük hale getirir.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cultereinfo"></param>
        /// <returns></returns>
        public static string FirstCharToUpper(this string text, string cultereinfo = "tr-TR")
        {
            string tmp = text[0].ToString().ToUpper(cultereinfo);
            string tmp2 = text.Remove(0).ToLower(cultereinfo);
            return tmp + tmp2;
        }

        /// <summary>
        /// CultureInfo nesnesi ile string değeri 'Ad SOYAD' yada 'Ad1 Ad2 SOYAD' formatında verir.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cultereinfo"></param>
        /// <returns></returns>
        public static string ToFirstnameSURNAME(this string text, string cultereinfo = "tr-TR")
        {
            string[] texts = text.Split(" ");
            string tmp = "";
            for (int i = 0; i < texts.Length; i++)
            {
                if (i == texts.Length)
                    tmp += texts[i].ToUpper(cultereinfo);
                else
                    tmp += texts[i].FirstCharToUpper(cultereinfo);
            }
            return tmp;
        }

        public enum RegexPattern
        {
            PhoneNumber,
            Email,
            URL
        }

        private static string GetRegexPattern(RegexPattern pattern)
        {
            switch (pattern)
            {
                case RegexPattern.PhoneNumber:
                    return @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
                case RegexPattern.Email:
                    return @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                case RegexPattern.URL:
                    return @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Verilen verilen ifadenin metinde olup olmadığını döner.
        /// </summary>
        /// <param name="text"></param> 
        /// <returns>bool</returns>
        public static bool IsMatch(this string text, string exp)
        {
            return new Regex(exp).IsMatch(text);
        }

        /// <summary>
        /// Verilen başlangıç ve bitiş ifadeleri arasında eşleşen ifadeleri liste olarak döner.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="startExp">Başlangıç ifadesi</param>
        /// <param name="endExp">Bitiş ifadesi</param>
        /// <returns>List<string></returns>
        public static List<string> GetExpressions(this string text, string startExp, string endExp)
        {
            List<string> matchExpressions = new List<string>();
            Regex regex = new Regex($"{startExp}(.+?){endExp}");
            MatchCollection matchList = regex.Matches(text);
            foreach (var exp in matchList)
                matchExpressions.Add(exp.ToString());

            return matchExpressions;
        }

        /// <summary>
        /// Verilen başlangıç ifadesi ile eşleşen ifadeleri liste olarak döner.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="startExp">Başlangıç ifadesi</param> 
        /// <returns>List<string></returns>
        public static List<string> GetExpressions(this string text, string startExp)
        {
            List<string> matchExpressions = new List<string>();
            Regex regex = new Regex(startExp + @"(.+?)\w+");
            MatchCollection matchList = regex.Matches(text);
            foreach (var exp in matchList)
                matchExpressions.Add(exp.ToString());

            return matchExpressions;
        }

        /// <summary>
        /// Verilen Regex patternine göre eşleşen ifadeleri döner.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns>List<string></returns>
        public static List<string> GetExpressionsWithPattern(this string text, string pattern)
        {
            List<string> matchExpressions = new List<string>();
            Regex regex = new Regex(pattern);
            MatchCollection matchList = regex.Matches(text);
            foreach (var exp in matchList)
                matchExpressions.Add(exp.ToString());

            return matchExpressions;
        }

        /// <summary>
        /// Verilen Regex patternine göre eşleşen ifadeleri döner.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns>List<string></returns>
        public static List<string> GetExpressionsWithPattern(this string text, RegexPattern pattern)
        {
            List<string> matchExpressions = new List<string>();
            Regex regex = new Regex(GetRegexPattern(pattern));
            MatchCollection matchList = regex.Matches(text);
            foreach (var exp in matchList)
                matchExpressions.Add(exp.ToString());

            return matchExpressions;
        }
    }
}
