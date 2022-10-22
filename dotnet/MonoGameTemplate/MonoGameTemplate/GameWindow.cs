using Microsoft.Extensions.Options;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Shapes;
using MonoGameTemplate.Extensions;
using MonoGameTemplate.Models.Configuration;

namespace MonoGameTemplate;

internal class GameWindow : Game, IGameWindow
{
	private readonly IOptions<GameOptions> _gameOptions;
	private readonly ILogger<GameWindow> _logger;
	private readonly IOptions<GameState> _gameState;
	private readonly IDrawer _drawer;
	private readonly IInputService _inputService;

	public Vector2 Center { get; private set; }
	public Game Game => this;

	private SpriteFont _spriteFont;

	public Point MousePosition { get; set; }

	public GameWindow(IOptions<GameOptions> gameOptions, ILogger<GameWindow> logger, IOptions<GameState> gameState, IDrawer drawer, IInputService inputService) : base()
	{
		_gameOptions = gameOptions;
		_logger = logger;
		_gameState = gameState;
		_drawer = drawer;
		_inputService = inputService;

		Content.RootDirectory = nameof(Content);
		IsFixedTimeStep = _gameOptions.Value.FixedTimeStep;
		IsMouseVisible = _gameOptions.Value.ShowPointer;
		Window.AllowUserResizing = _gameOptions.Value.AllowUserResizing;
		Window.ClientSizeChanged += (_, _) => Center = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
	}

	protected override void LoadContent()
	{
		_spriteFont = Content.Load<SpriteFont>("Text");
		_gameState.Value.SpriteBatch = GraphicsDevice.CreateSpriteBatch();
		Center = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
		_inputService.GuiMouseListener.MouseMoved += GuiMouseListenerOnMouseMoved;
		base.LoadContent();
	}

	private void GuiMouseListenerOnMouseMoved(object? sender, MouseEventArgs e)
	{
		MousePosition = e.Position;
		//_gameState.Value.MousePointerPosition = e.Position;
	}

	public Vector2 Velocity { get; set; }
	public Vector2 Position { get; set; }

	protected override void Update(GameTime gameTime)
	{
		var updateTime = gameTime.ElapsedGameTime.TotalMilliseconds - _gameState.Value.GameTime.ElapsedGameTime.TotalMilliseconds;
		var timeScalar = updateTime / 0.5;
		this.Velocity += this.acceleration * timeScalar;
		this.Position += this.Velocity;

		_gameState.Value.GameTime = gameTime;
		GraphicsDevice.Clear(Color.Black);

		_inputService.GuiMouseListener.Update(gameTime);
		_inputService.GuiKeyboardListener.Update(gameTime);
		_inputService.GuiGamePadListener.Update(gameTime);
		_inputService.GuiTouchListener.Update(gameTime);

		_drawer.Begin();

		_drawer.DrawPolygon(Center, new Polygon(new List<Vector2>() { Center, new Vector2(0.001f, 0.002f), Vector2.UnitX }), Color.Beige);

		_drawer.DrawPolygon(Center, new Rectangle(Point.Zero, new Point(50, 50)).GetPolygon(), Color.IndianRed);

		_drawer.DrawString(_spriteFont, MousePosition.ToString(), GraphicsDevice.GetOrigin().ToVector2(), Color.Aqua);
		_drawer.DrawString(_spriteFont, Center.ToString(), GraphicsDevice.GetOrigin().ToVector2().Add(500, 0), Color.Aqua);

		_drawer.End();

		base.Update(gameTime);
	}
}