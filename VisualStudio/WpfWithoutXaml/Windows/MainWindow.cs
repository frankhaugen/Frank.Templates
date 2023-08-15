using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Frank.Templates.NoXaml.Solution.Windows;

public class MainWindow : Window
{
    private readonly ILogger<MainWindow> _logger;

    private readonly Button _button;

    public MainWindow(ILogger<MainWindow> logger)
    {
        _logger = logger;
        _button = new Button()
        {
            Content = "ClickMe!"
        };

        _button.Click += ButtonOnClick;

        MinWidth = 1024;
        MinHeight = 512;
        MaxHeight = MinHeight * 2;
        MaxWidth = MinWidth * 2;

        SizeToContent = SizeToContent.WidthAndHeight;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;

        var label = new Label() { Content = "C# > XAML" };
        var grid = new Grid();
        grid.Children.Add(label);

        Content = grid;
    }

    private void ButtonOnClick(object sender, RoutedEventArgs e)
    {
        _logger.LogInformation("Button clicked!");
        MessageBox.Show("Button clicked!");
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        _logger.LogInformation("Closing");
        base.OnClosing(e);
    }
}