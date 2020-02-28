using System;
using System.Reflection;
using static System.Console;
using static System.ConsoleColor;

namespace Intent.Console
{
    internal class ConsoleLogger : IRunLogger
    {
        public void WriteTestInconclusive(MethodInfo m)
        {
            var currentColor = ForegroundColor;
            ForegroundColor = Yellow;
            WriteLine($"[?] {m.Name} inconclusive");
            ForegroundColor = currentColor;
        }

        public void WriteTestPassed(MethodInfo m)
        {
            var currentColor = ForegroundColor;
            ForegroundColor = Green;
            WriteLine($"[+] {m.Name} passed");
            ForegroundColor = currentColor;
        }

        public void WriteTestFailure(MethodInfo m, Exception ex)
        {
            var currentColor = ForegroundColor;
            ForegroundColor = Red;
            WriteLine($"[-] {m.Name} failed{Environment.NewLine}{ex}");
            ForegroundColor = currentColor;
        }

        public void WriteFrameworkError(Exception ex)
        {
            var currentColor = ForegroundColor;
            ForegroundColor = DarkRed;
            WriteLine($"[-] framework failed{Environment.NewLine}{ex}{Environment.NewLine}{Environment.NewLine}");
            ForegroundColor = currentColor;
        }
    }
}