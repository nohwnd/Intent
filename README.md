# 🌵 Intent
A toy testing framework that starts from and inconclusive test, and not from a passing test like most other frameworks, and you need to show it that your test should actually pass by providing an assertion. This is an attempt to learn more about microsoft test platform, and also a proof of concept that all frameworks don't have to be the same.

- ✔ code the basic idea
- ✔ have a standalone console runner
- ✔ integration with dotnet test
- ✔ basic integration with VS Test Explorer

### TODO:
-    parallel runs
-    offloading the work to a test host process

```cs
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
```
