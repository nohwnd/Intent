namespace Intent.Console
{
    class Program
    {
        static void Main(string[] path)
        {
            new Runner().Run(path, new ConsoleLogger());
        }
    }
}
