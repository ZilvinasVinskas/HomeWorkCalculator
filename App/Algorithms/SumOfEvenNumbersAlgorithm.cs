using HomeworkCalculator.ResultWriter;

namespace HomeworkCalculator.Algorithms;

public class SumOfEvenNumbersAlgorithm : IAlgorithm<SumOfEvenNumbersAlgorithm>
{
    public long SumOfEvenNumbers { get; set; } = 0;

    public void Feed(int number)
    {
        if (number % 2 == 0)
        {
            SumOfEvenNumbers += number;
        }
    }

    public void PrintResult(IResultWriter resultWriter)
    {
        resultWriter.WriteResult("Sum of even numbers", SumOfEvenNumbers.ToString());
    }
}