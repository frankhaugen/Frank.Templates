using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Frank.Templates.NoXaml.Solution.Controls;
using Frank.Templates.NoXaml.Solution.Core;

namespace Frank.Templates.NoXaml.Solution.App;

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