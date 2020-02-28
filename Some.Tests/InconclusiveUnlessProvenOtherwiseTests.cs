using System;
using Intent;
using Intent.Assertions;

namespace Some.Tests
{
    public class InconclusiveUnlessProvenOtherwiseTests
    {
        public void EmptyTest()
        {
            // all tests start as inconclusive
            // and not as passing as in some other frameworks
        }

        public void InconclusiveTest()
        {
            var sut = new Some();
            var one = sut.One();

            // this test will be inconclusive because we don't 
            // have any assertion that would prove we did something 
            // that was expected
        }

        public void PassingTest()
        {
            var sut = new Some();
            var one = sut.One();

            // this test proves that we expected 1 and we got 1
            // so it will be passing
            Assert.AreEqual(1, one);
        }

        public void FailingTest()
        {
            var sut = new Some();
            var one = sut.One();

            // this test proves that we expected 2, but we got 1
            // so it will be failing
            Assert.AreEqual(2, one);
        }

        public void FailingTestWithException()
        {
            // this test encountered an exception
            // so it will be failing
            throw new Exception("something unexpected happened");
        }
    }

    [Exclude]
    public class Some
    {
        public int One() { return 1; }
    }
}
