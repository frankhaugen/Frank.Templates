using System.Globalization;
using System.Runtime.InteropServices;

using Frank.Templates.NoXaml.Solution.Windows;

namespace Frank.Templates.NoXaml.Solution;

public class Program
{
    [DllImport("kernel32")]
    static extern bool AllocConsole();

    [STAThread]
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        AllocConsole();

        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddScoped<App>();

                // Register your dependencies here

                // Register these last, in this order
                services.AddScoped<MainWindow>();
                services.AddHostedService<WindowHost>();
            }).Build();

        host.Run();
    }
}