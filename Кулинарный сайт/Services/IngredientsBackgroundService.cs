using Кулинарный_сайт.Interfaces;
using Кулинарный_сайт.Models;

namespace Кулинарный_сайт.Services
{

    public class IngredientsBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<IngredientsBackgroundService> _logger;

        public IngredientsBackgroundService(IServiceScopeFactory serviceScopeFactory, ILogger<IngredientsBackgroundService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Delayed book processing service starting...");

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var IngredientsService = scope.ServiceProvider.GetRequiredService<IIngredientsService>();
                    // Call your BookService methods here
                    Ingredients ingredients = new Ingredients()
                    {
                       
                    };
                    //await bookService.AddBookAsync(bookVm); // Replace with your actual book processing logic

                    //some logic
                }

                _logger.LogInformation("Delayed book processing completed. Waiting 15 seconds...");
                await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
            }
        }
    }
}
