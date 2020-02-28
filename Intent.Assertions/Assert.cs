namespace Intent.Assertions
{
    public class Assert
    {
        public static void AreEqual<T>(T expected, T actual)
        {
            if (expected.Equals(actual))
            {
                throw new TestPassedException();
            }
            else
            {
                throw new TestFailedException($"Expected {expected}, but got {actual}."); 
            }
        }
    }
}
