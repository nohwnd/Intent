using System;
using System.Reflection;

namespace Intent
{
    public interface IRunLogger
    {
        void WriteTestPassed(MethodInfo m);
        void WriteTestInconclusive(MethodInfo m);
        void WriteTestFailure(MethodInfo m, Exception ex);
        void WriteFrameworkError(Exception ex);
    }
}