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

                    services.AddScoped<ICollisiumSandbox, CollisiumSandbox>();


                    // Зарегистрировать партнеров и их стратегии

                });

        }
        /*public static void Main(string[] args)
        {
            
            
        }*/
    }
    internal sealed class CollisiumExperimentWorker : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly ICollisiumSandbox _collisiumSandbox;
        private const int EXPERIMENTS_COUNT = 1000000;
        public CollisiumExperimentWorker(
            ILogger<CollisiumExperimentWorker> logger,
            IHostApplicationLifetime appLifetime,
            ICollisiumSandbox collisiumSandbox
            )
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _collisiumSandbox = collisiumSandbox;
        }
        private void StartGame()
        {
            Player musk = new("Musk")
            {
                Strategy = new ZeroStrategy()
            };
            Player zuckerberg = new("Musk")
            {
                Strategy = new FirstCardColorStrategy()
            };
            int wins = 0;
            Deck deck = Deck.GetStandardDeck();
            for (int i = 0; i < EXPERIMENTS_COUNT; i++)
            {
                deck.RandomShuffle();
                musk.Deck = deck.GetFirstNCardsDeck(deck.Size() / 2);
                zuckerberg.Deck = deck.GetLastNCardsDeck(deck.Size() / 2);
                wins += _collisiumSandbox.Play(musk, zuckerberg) ? 1 : 0;
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