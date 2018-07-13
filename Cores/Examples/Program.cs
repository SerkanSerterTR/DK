using System;
using System.Data.Entity;
using Cores.CoreExtensions;

namespace Examples
{
    class Program
    {
        class Object1
        {
            public int Val1 { get; set; }
            public string Val2 { get; set; }
        }

        class Object2
        {
            public int Val1 { get; set; }
            public string Val2 { get; set; }
        }

        static DbSet<Object1> db { get; set; }

        static void Main(string[] args)
        {
            Object1 object1 = new Object1();
            object1.Val1 = 1;
            object1.Val2 = "ss";

            Object2 object2 = new Object2();
            object2.Val1 = 2;
            object2.Val2 = "qq";
            object1.CopyProperties(ref object2);

            var ob2val2 = object2.Val2;

            //var list = db.GetList(p => p.Val1 == 1);

            bool t = object2.Val1.IsEqual(2);

            Console.WriteLine(ob2val2);
            Console.ReadKey();
        }
    }
}
