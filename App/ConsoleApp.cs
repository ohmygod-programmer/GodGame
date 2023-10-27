using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GodGameLibrary;
using GodGameLibrary.Strategies;
namespace Musk
{
    internal sealed class ConsoleApp
    {
        public static void Main(string[] args)

        {

            CreateHostBuilder(args).Build().Run();

        }



        public static IHostBuilder CreateHostBuilder(string[] args)

        {

            return Host.CreateDefaultBuilder(args)

                .ConfigureServices((hostContext, services) =>

                {

                    services.AddHostedService<CollisiumExperimentWorker>();

                    services.AddScoped<CollisiumSandbox>();
                    services.AddScoped<Deck>(d => Deck.GetStandardDeck());
                    services.AddScoped<Player>(p => new Player("Musk", new FirstCardColorStrategy()));
                    services.AddScoped<Player>(p => new Player("Zukerberg", new ZeroStrategy()));


                    // Зарегистрировать партнеров и их стратегии

                });

        }
      

    }
    internal sealed class CollisiumExperimentWorker : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly CollisiumSandbox _collisiumSandbox;
        private readonly Deck _deck;
        private const int EXPERIMENTS_COUNT = 1000000;
        public CollisiumExperimentWorker(
            ILogger<CollisiumExperimentWorker> logger,
            IHostApplicationLifetime appLifetime,
            CollisiumSandbox collisiumSandbox,
            Deck deck
            )
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _collisiumSandbox = collisiumSandbox;
            _deck = deck;
        }
        private void StartGame()
        {
            int wins = 0;
            for (int i = 0; i < EXPERIMENTS_COUNT; i++)
            {
                _deck.RandomShuffle();
                wins += _collisiumSandbox.Play(_deck) ? 1 : 0;
            }
            Console.WriteLine("Ребята выиграли " + wins + " раз из " + EXPERIMENTS_COUNT);

        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(StartGame, cancellationToken);
            return Task.CompletedTask;

        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}