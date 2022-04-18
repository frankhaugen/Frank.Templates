namespace MonoGameGame
{
    public class GameHost : BackgroundService
    {
        private readonly ILogger<GameHost> _logger;

        public GameHost(ILogger<GameHost> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var gameWindow = new GameWindow();
            gameWindow.Run();
        }
    }
}