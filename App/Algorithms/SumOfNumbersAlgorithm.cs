using HomeworkCalculator.ResultWriter;

namespace HomeworkCalculator.Algorithms;

public class SumOfNumbersAlgorithm : IAlgorithm<SumOfNumbersAlgorithm>
{
    public long SumOfNumbers { get; set; } = 0;

    public void Feed(int number)
    {
        SumOfNumbers += number;
    }

    public void PrintResult(IResultWriter resultWriter)
    {
        resultWriter.WriteResult("Sum of numbers", SumOfNumbers.ToString());
    }
}