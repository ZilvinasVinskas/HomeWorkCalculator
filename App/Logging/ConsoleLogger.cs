namespace HomeworkCalculator.Logging;

public class ConsoleLogger : ILogger
{
    public void LogError(string error)
    {
        Console.WriteLine(error);
    }
}