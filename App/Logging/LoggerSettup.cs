namespace HomeworkCalculator.Logging;

// DI, kad būtų galima injectinti visus esamus loggerius, ir loginti ta pačią informacija onelineriu į kelias skirtingas vietas.
// Console, failą, cloudą, etc...
// Greičiausia overengineering'as, tačiau norėjau pažiūrėti kaip gausis.

public class LoggerSettup : ILoggerSettup 
{
    private readonly IEnumerable<ILogger> _loggers;
    public LoggerSettup(IEnumerable<ILogger> loggers) =>
    _loggers = loggers;

    public void LogError(string error)
    {
        _loggers.AsParallel().ForAll(x => x.LogError(error));
    }
}