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
    }
}
