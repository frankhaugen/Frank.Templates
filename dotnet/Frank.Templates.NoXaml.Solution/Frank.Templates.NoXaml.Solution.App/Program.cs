using System.Runtime.InteropServices;
using System.Windows;
using Frank.Templates.NoXaml.Solution.App.Extensions;
using Frank.Templates.NoXaml.Solution.Core;

namespace Frank.Templates.NoXaml.Solution.App;

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