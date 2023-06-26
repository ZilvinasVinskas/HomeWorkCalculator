using HomeworkCalculator.ResultWriter;

namespace HomeworkCalculator.Algorithms;

public interface IAlgorithm<T>
{
    void Feed(int number);
    void PrintResult(IResultWriter resultWriter);
}