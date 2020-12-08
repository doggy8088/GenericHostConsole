using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GenericHostConsole
{
    public class App : IHostedService
    {
        private readonly ILogger<App> logger;
        private readonly IHostApplicationLifetime appLifetime;

        public App(ILogger<App> logger, IHostApplicationLifetime appLifetime)
        {
            this.logger = logger;
            this.appLifetime = appLifetime;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogWarning("Worker running at: {time}", DateTimeOffset.Now);

            await Task.Yield();

            appLifetime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogWarning("Worker stopped at: {time}", DateTimeOffset.Now);
            return Task.CompletedTask;
        }
    }
}