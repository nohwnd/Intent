using System;

namespace Intent
{
    public class TestFailedException : Exception
    {
        public TestFailedException(string message) : base(message)
        {
        }
    }
}
