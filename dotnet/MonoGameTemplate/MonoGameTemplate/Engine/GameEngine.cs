using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input.InputListeners;

namespace MonoGameTemplate.Engine;

public class GameEngine
{
	private readonly IGameWindow _gameWindow;
	private readonly IDrawer _drawer;
	private readonly IInputService _inputService;
	private readonly ILogger<GameEngine> _logger;
	private readonly SpriteBatch _spriteBatch;

	public GameEngine(IGameWindow gameWindow, IDrawer drawer, IInputService inputService, ILogger<GameEngine> logger)
	{
		_gameWindow = gameWindow;
		_drawer = drawer;
		_inputService = inputService;
		_logger = logger;
	}

	public void Run()
	{
		_gameWindow.Run();
	}

	public void Draw()
	{
		_drawer.Begin();

		_drawer.DrawString(_spriteBatch., "Hello World!", new Vector2(100, 100), Color.White);

		_drawer.End();
	}

	public void Dispose()
	{
		_gameWindow.Dispose();
	}

	public void Exit()
	{
		_gameWindow.Exit();
	}
}

public readonly record struct 