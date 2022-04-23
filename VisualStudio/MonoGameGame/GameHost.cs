using Microsoft.Xna.Framework;

namespace MonoGameGame;

public class GameHost : BackgroundService
{

    public static GraphicsDeviceManager Graphics;

    private readonly ILogger<GameHost> _logger;
    private readonly IGameWindow _gameWindow;

    public GameHost(ILogger<GameHost> logger, IGameWindow gameWindow)
    {
        _logger = logger;
        _gameWindow = gameWindow;
        Graphics = new GraphicsDeviceManager(_gameWindow.Game);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Game started at: {time}", DateTime.UtcNow);
        _gameWindow.Run();
    }

    private void Exit(object sender, EventArgs e)
    {
        _gameWindow.Exit();
        _gameWindow.Dispose();
        StopAsync(new CancellationToken()).GetAwaiter().GetResult();
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Game stopped at: {time}", DateTime.UtcNow);
        await base.StopAsync(cancellationToken);
    }
}