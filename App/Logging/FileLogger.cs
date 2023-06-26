namespace HomeworkCalculator.Logging;

public class FileLogger : ILogger
{
    public void LogError(string error)
    {
        Console.WriteLine("Logger2: " + error); //Consoles loggerio kopija, kad matytūsi, jog veikia abu.
    }
}