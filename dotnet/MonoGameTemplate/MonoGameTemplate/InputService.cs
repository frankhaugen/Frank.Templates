using Microsoft.Extensions.Options;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;
using MonoGameTemplate.Models.Configuration;

namespace MonoGameTemplate;

public class InputService : IInputService
{
	private readonly IOptions<GameState> _options;
	private readonly ILogger<InputService> _logger;

	public InputService(IOptions<GameState> options)
	{
		_options = options;
		GuiKeyboardListener = new KeyboardListener();
		GuiMouseListener = new MouseListener();
		GuiGamePadListener = new GamePadListener();
		GuiTouchListener = new TouchListener();
	}

	public KeyboardListener GuiKeyboardListener { get; }
	public MouseListener GuiMouseListener { get; }
	public GamePadListener GuiGamePadListener { get; }
	public TouchListener GuiTouchListener { get; }
}