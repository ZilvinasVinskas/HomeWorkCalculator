using HomeworkCalculator.Algorithms;
using HomeworkCalculator.Logging;
using HomeworkCalculator.ResultWriter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    await services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

static IHostBuilder CreateHostBuilder(string[] strings) => Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddScoped<IResultWriter, ConsoleResultWriter>();
            services.AddScoped<IAlgorithm<SumOfEvenNumbersAlgorithm>, SumOfEvenNumbersAlgorithm>();
            services.AddScoped<IAlgorithm<SumOfNumbersAlgorithm>, SumOfNumbersAlgorithm>();
            services.AddScoped<ILogger, ConsoleLogger>();
            services.AddScoped<ILogger, FileLogger>();
            services.AddScoped<ILoggerSettup, LoggerSettup>();
            services.AddSingleton<App>();
        });