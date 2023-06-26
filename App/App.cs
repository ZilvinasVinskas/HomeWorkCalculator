using HomeworkCalculator.Algorithms;
using HomeworkCalculator.Logging;
using HomeworkCalculator.ResultWriter;

public class App
{
    private readonly ILoggerSettup _loggers;
    private readonly IAlgorithm<SumOfEvenNumbersAlgorithm> _sumOfevenNumberAlgorithm;
    private readonly IAlgorithm<SumOfNumbersAlgorithm> _sumOfNumberAlgorithm;
    private readonly IResultWriter _resultWriter;

    public App(
        ILoggerSettup loggers,
        IAlgorithm<SumOfEvenNumbersAlgorithm> sumOfevenNumberAlgorithm,
        IAlgorithm<SumOfNumbersAlgorithm> sumOfNumberAlgorithm,
        IResultWriter resultWriter)
    {
        _loggers = loggers;
        _sumOfevenNumberAlgorithm = sumOfevenNumberAlgorithm;
        _sumOfNumberAlgorithm = sumOfNumberAlgorithm;
        _resultWriter = resultWriter;
    }

    //Kuo paprasčiau padarytas algoritmas, kad tiktų kaip pvz.

    public async Task Run(string[] args)
    {
        try
        {
            Console.WriteLine("Enter file path:");
            string file = Console.ReadLine() ?? throw new ArgumentException("File path must be specified");
            using var fileReader = new StreamReader(file);

            var fileContent = await fileReader.ReadToEndAsync();
            //Panaudotas viso failo nuskaitymas, darant prielaidą, kad nebus specialiai pateikiamas per didelis failas.
            //Kitu atveju planas nuskaitinėti baitu bufferiais ir sudedinėti.

            var split = fileContent.Split(",");

            foreach (var segment in split)
            {
                try
                {
                    var number = int.Parse(segment);
                    _sumOfNumberAlgorithm.Feed(number);
                    _sumOfevenNumberAlgorithm.Feed(number);

                }
                catch (Exception e)
                {
                    _loggers.LogError(e.Message);
                }
            }

            _sumOfNumberAlgorithm.PrintResult(_resultWriter);
            _sumOfevenNumberAlgorithm.PrintResult(_resultWriter);
        }
        catch (IOException e)
        {
            _loggers.LogError(e.Message);
        }

    }
}