using System.Diagnostics;

namespace AutomaticExecution.Api;

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
        _timer = new Timer(Start, null, TimeSpan.Zero, TimeSpan.FromSeconds(6));
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

    public override void Dispose()
    {
        _timer.Dispose();
        base.Dispose();
    }
}