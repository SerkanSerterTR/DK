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
            var ss2 = ss.xClone();

            int a = 1;
            double b = a.xParse<int, double>();

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
