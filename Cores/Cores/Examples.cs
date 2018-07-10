using System;
using Cores.CoreExceptions;
using Cores.CoreExtensions;

namespace Cores
{
    class Examples
    {
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
