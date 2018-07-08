using System;
using System.Collections.Generic;
using System.Text;
using Cores.CoreExceptions;
using Cores.CoreExtensions;



namespace Cores
{
    class Class1
    {
        public void Examp()
        {
            Exceptions.ExceptionWithLog(Test, Log);
            var ss = new Class1();
            var ss2 = ss.xClone();

            int a = 1;
            double b = a.xParse<int,double>();

        }

        private object Log(Exception arg)
        {
            throw new NotImplementedException();
        }

        public object Test()
        {
            return new object();
        }
    }
}
