using MonoGame.Extended.Input.InputListeners;

namespace MonoGameTemplate;

public class InputService : IInputService
{
	public KeyboardListener GuiKeyboardListener { get; }
	public MouseListener GuiMouseListener { get; }
	public GamePadListener GuiGamePadListener { get; }
	public TouchListener GuiTouchListener { get; }
}