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
        public static string xToUpper(this string text, string cultereinfo = "tr-TR")
        {
            return text.ToUpper(new System.Globalization.CultureInfo(cultereinfo));
        }

        /// <summary>
        ///  CultureInfo nesnesi ile string değerdeki tüm harfleri küçültür.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cultereinfo"></param>
        /// <returns></returns>
        public static string xToLower(this string text, string cultereinfo = "tr-TR")
        {
            return text.ToLower(new System.Globalization.CultureInfo(cultereinfo));
        }

        /// <summary>
        /// CultureInfo nesnesi ile string değerdeki ilk harfini büyük diğerleri küçük hale getirir.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cultereinfo"></param>
        /// <returns></returns>
        public static string xFirstCharToUpper(this string text, string cultereinfo = "tr-TR")
        {
            string tmp = text[0].ToString().xToUpper(cultereinfo);
            string tmp2 = text.Remove(0).xToLower(cultereinfo);
            return tmp + tmp2;
        }

        /// <summary>
        /// CultureInfo nesnesi ile string değeri 'Ad SOYAD' yada 'Ad1 Ad2 SOYAD' formatında verir.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cultereinfo"></param>
        /// <returns></returns>
        public static string xToFirstnameSURNAME(this string text, string cultereinfo = "tr-TR")
        {
            string[] texts = text.Split(" ");
            string tmp = "";
            for (int i = 0; i < texts.Length; i++)
            {
                if (i == texts.Length)
                    tmp += texts[i].xToUpper(cultereinfo);
                else
                    tmp += texts[i].xFirstCharToUpper(cultereinfo);
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
        public static bool xIsMatch(this string text, string exp)
        {
            return new Regex(exp).IsMatch(text);
        }

        /// <summary>
        /// Verilen başlangıç ve bitiş ifadeleri arasında eşleşen ifadeleri liste olarak döner.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="firstExp">Başlangıç ifadesi</param>
        /// <param name="lastExp">Bitiş ifadesi</param>
        /// <returns>List<string></returns>
        public static List<string> xGetExpressions(this string text, string firstExp, string lastExp)
        {
            List<string> matchExpressions = new List<string>();
            Regex regex = new Regex($"{firstExp}(.+?){lastExp}");
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
        public static List<string> xGetExpressionsWithPattern(this string text, string pattern)
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
        public static List<string> xGetExpressionsWithPattern(this string text, RegexPattern pattern)
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
