using System.Diagnostics;

namespace AutomaticExecution.Api;

public class ExecutionHandler : IHostedService, IDisposable
{
    private readonly ILogger<ExecutionHandler> _logger;
    private Timer _timer;
    private readonly Stopwatch stopwatch;

    public ExecutionHandler(ILogger<ExecutionHandler> logger)
    {
        stopwatch = new();
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Serviço iniciado...");
        _timer = new Timer(Start, null, TimeSpan.Zero, TimeSpan.FromSeconds(6));

        return Task.CompletedTask;
    }

    private void Start(object state)
    {
        stopwatch.Start();
        var soma = 4 + 5;
        _logger.LogInformation($"{soma}");

        stopwatch.Stop();
        Console.WriteLine($"Tempo de execução: {stopwatch.ElapsedMilliseconds} ms");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Serviço de pedidos finalizado.");

        return Task.CompletedTask;
    }

    public void Dispose() => _timer?.Dispose();
}