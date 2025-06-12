namespace HeliosTowers_Tests
{
    public interface ILogger { void Log(string message); }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message) => Console.WriteLine(message);
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllText("log.txt", $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}
