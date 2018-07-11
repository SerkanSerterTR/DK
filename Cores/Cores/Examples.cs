using System;
using Cores.CoreExceptions;
using Cores.CoreExtensions;

namespace Cores
{
    class Examples
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

        public void Examp()
        {
            Exceptions.ThrowException(Test);
            Exceptions.ThrowException(() => { throw new NotImplementedException(); });
            Exceptions.ExceptionWithVoidLog(Test, Log);
            Exceptions.ExceptionWithVoidLog(
                () =>
                {
                    throw new NotImplementedException();
                },
                (Exception ex) =>
                {
                    string msg = ex.Message;
                    throw new NotImplementedException();
                });
            var ss = new Examples();
            var ss2 = ss.Clone();

            int a = 1;
            double b = a.Parse<int, double>();

            string email = "se@mm.com 9798798asdads s2@mm.com";
            var result = email.GetExpressionsWithPattern(Extensions.RegexPattern.Email);


            Object1 object1 = new Object1();
            object1.Val1 = 1;
            object1.Val2 = "ss";

            Object2 object2 = new Object2();
            object1.Val1 = 2;
            object1.Val2 = "qq";
            object1.CopyProperties(ref object2);

            var ob2val2 = object2.Val2;
        }

        private void Log(Exception arg)
        {
            throw new NotImplementedException();
        }

        public void Test()
        {
            throw new NotImplementedException();
        }
    }
}
