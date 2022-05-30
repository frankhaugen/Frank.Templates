using System.Runtime.InteropServices;
using System.Windows;
using WpfWithoutXaml.App.Extensions;
using WpfWithoutXaml.Core;

namespace WpfWithoutXaml.App;

internal class Program
{
    [STAThread]
    public static void Main(params string[] args)
    {
        AllocConsole();

        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                context.SetContentPathToApplicationDirectory();

                services.AddScoped<Application>();
                services.AddScoped<ITemperatureConverterService, TemperatureConverterService>();

                services.AddHostedService<Worker>();

                services.AddScoped<MainWindow>();
                services.AddHostedService<WindowHost>();
            })
            .Build();

        host.Run();

    }

    [DllImport("kernel32")]
    static extern bool AllocConsole();
}