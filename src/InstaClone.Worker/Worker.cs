namespace InstaClone.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            // Example task: Generate a daily report or clean up old data.
            _logger.LogInformation("Performing daily cleanup task...");
            await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
        }
    }
}
