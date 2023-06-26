namespace HomeworkCalculator.ResultWriter;

public class ConsoleResultWriter : IResultWriter
{
    public void WriteResult(string name, string value)
    {
        Console.WriteLine("----------------");
        Console.WriteLine($"{name}: {value}");
    }
}