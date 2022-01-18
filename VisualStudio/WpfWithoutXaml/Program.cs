using System.Globalization;
using System.Runtime.InteropServices;

using WpfWithoutXaml.Windows;

namespace WpfWithoutXaml;

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