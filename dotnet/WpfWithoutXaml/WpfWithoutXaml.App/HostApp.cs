using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using WpfWithoutXaml.Controls;
using WpfWithoutXaml.Core;

namespace WpfWithoutXaml.App;

internal class WindowHost : BackgroundService
{
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
        var app = scope.ServiceProvider.GetRequiredService<Application>();

        app.ShutdownMode = ShutdownMode.OnMainWindowClose;
        app.Exit += (sender, args) =>
        {
            FreeConsole();
            app.Shutdown();
            Environment.Exit(0);
            _logger.LogInformation("Stopping");
        };

        app.Run(window);
    }

    [DllImport("kernel32")]
    private static extern bool FreeConsole();
}

internal class MainWindow : Window
{
    private readonly ILogger<MainWindow> _logger;
    private readonly ITemperatureConverterService _converterService;
    private readonly MyTextBox _textBox;

    public MainWindow(ILogger<MainWindow> logger, ITemperatureConverterService converterService)
    {
        _logger = logger;
        _converterService = converterService;
        _textBox = new MyTextBox("Write something", (o, args) => MessageBox.Show((o as TextBox)?.Text ?? ""));

        ConfigureWindow();

        Content = _textBox;
    }

    private void ConfigureWindow()
    {
        MinWidth = 512;
        MinHeight = 256;

        SizeToContent = SizeToContent.WidthAndHeight;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        _logger.LogInformation("Closing");
        base.OnClosing(e);
    }
}