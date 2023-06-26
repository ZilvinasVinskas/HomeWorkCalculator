using HomeworkCalculator.Algorithms;

namespace Tests;

public class AlgorythmTests
{
    [Fact]
    public void SumOfNumbersAgorithmCalculatesSumCorrectly()
    {
        var input = new int[] { 1, 2, 3, 4 };
        var expected = 10;
        var algorithm = new SumOfNumbersAlgorithm();

        Array.ForEach(input, algorithm.Feed);
        Assert.Equal(expected, algorithm.SumOfNumbers);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, 6)]
    [InlineData(new int[] { 1, 3, 5 }, 0)]
    [InlineData(new int[] { 2, 2, 4, 4 }, 12)]
    public void SumOfEvenNumbersAgorithmCalculatesSumCorrectly(int[] numbers, int expected)
    {
        var algorithm = new SumOfEvenNumbersAlgorithm();

        Array.ForEach(numbers, algorithm.Feed);
        Assert.Equal(expected, algorithm.SumOfEvenNumbers);
    }
}