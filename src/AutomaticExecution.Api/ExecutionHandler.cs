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
        _timer = new Timer(Start, 3, TimeSpan.Zero, TimeSpan.FromSeconds(6));

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

public class ExecuTionHandler2 : BackgroundService
{
    private Timer _timer;
    private readonly Stopwatch _stopwatch;

    public ExecuTionHandler2()
    {
        _stopwatch = new();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _timer = new Timer(Start, 3, TimeSpan.Zero, TimeSpan.FromSeconds(6));
        return Task.CompletedTask;
    }

    private void Start(object state)
    {
        _stopwatch.Start();
        var soma = 4 + 4;
        Console.WriteLine(soma);
        _stopwatch.Stop();
        Console.WriteLine($"Tempo de execução: {_stopwatch.ElapsedMilliseconds} ms");
    }

    public override void Dispose() => _timer.Dispose();
}