using System.Runtime.InteropServices;
using System.Windows;

using WpfWithoutXaml.Windows;

namespace WpfWithoutXaml;

public class WindowHost : BackgroundService
{
    [DllImport("kernel32")]
    static extern bool FreeConsole();

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<WindowHost> _logger;

    public WindowHost(IServiceProvider serviceProvider, ILogger<WindowHost> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Starting");

        using var scope = _serviceProvider.CreateScope();
        var window = scope.ServiceProvider.GetRequiredService<MainWindow>();
        var app = scope.ServiceProvider.GetRequiredService<App>();

        app.ShutdownMode = ShutdownMode.OnMainWindowClose;
        app.Exit += (sender, args) =>
        {
            FreeConsole();
            app.Shutdown();
            Environment.Exit(0);
        };

        app.Run(window);
    }
}