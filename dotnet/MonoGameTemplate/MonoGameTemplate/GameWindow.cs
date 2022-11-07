using Microsoft.Extensions.Options;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;
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

		MaxElapsedTime = TimeSpan.FromSeconds(5);
		TargetElapsedTime = TimeSpan.FromSeconds(0.33);

		IsFixedTimeStep = _gameOptions.Value.FixedTimeStep;
		IsMouseVisible = _gameOptions.Value.ShowPointer;
		Window.AllowUserResizing = _gameOptions.Value.AllowUserResizing;
		Window.ClientSizeChanged += (_, _) => Center = GraphicsDevice.Viewport.Bounds.Center.ToVector2();

		_inputService.GuiKeyboardListener.KeyPressed += GuiKeyboardListenerOnKeyTyped;
	}

	protected override void LoadContent()
	{
		_spriteFont = Content.Load<SpriteFont>("Text");
		_gameState.Value.SpriteBatch = GraphicsDevice.CreateSpriteBatch();
		Center = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
		BallPosition = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
		_inputService.GuiMouseListener.MouseMoved += GuiMouseListenerOnMouseMoved;
		base.LoadContent();
	}

	private void GuiMouseListenerOnMouseMoved(object? sender, MouseEventArgs e)
	{
		MousePosition = e.Position;
	}

	protected override void Update(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.Black);

		_gameState.Value.GameTime = gameTime;

		_inputService.GuiMouseListener.Update(gameTime);
		_inputService.GuiKeyboardListener.Update(gameTime);
		_inputService.GuiGamePadListener.Update(gameTime);
		_inputService.GuiTouchListener.Update(gameTime);

		_drawer.Begin();

		//_logger.LogInformation(gameTime.TotalGameTime.ToString());
		//_logger.LogInformation(gameTime.GetElapsedSeconds().ToString());

		BallPosition = NextPosition(BallPosition, _gameState.Value.GameTime.TotalGameTime.Seconds, 10);

		_drawer.DrawCircl(BallPosition, 10, 42, Color.Aqua);
		Console.WriteLine(BallPosition.ToString());

		_drawer.DrawString(_spriteFont, MousePosition.ToString(), GraphicsDevice.GetOrigin().ToVector2(), Color.Aqua);
		_drawer.DrawString(_spriteFont, Center.ToString(), GraphicsDevice.GetOrigin().ToVector2().Add(500, 0), Color.Aqua);
		_drawer.DrawString(_spriteFont, BallPosition.ToString(), GraphicsDevice.GetOrigin().ToVector2().Add(0, 25), Color.Aqua);
		//_drawer.DrawString(_spriteFont, gameTime.ElapsedGameTime.ToString(), GraphicsDevice.GetOrigin().ToVector2().Add(300, 0), Color.Aqua);
		//_drawer.DrawString(_spriteFont, gameTime.TotalGameTime.ToString(), GraphicsDevice.GetOrigin().ToVector2().Add(600, 0), Color.Aqua);

		_drawer.End();

		base.Update(gameTime);
	}

	private void GuiKeyboardListenerOnKeyTyped(object? sender, KeyboardEventArgs e)
	{
		if (e.Key == Keys.Space)
		{
			BallPosition = NextPosition(BallPosition, _gameState.Value.GameTime.TotalGameTime.Seconds, 45);
			_logger.LogInformation(BallPosition.ToString());
		}
	}

	public Vector2 BallPosition { get; set; }
	public float BallLinearVelocity { get; set; }

	Vector2 NextPosition(Vector2 origin, float time, float angle)
	{
		var gravity = -9.80665F;
		var gravityModifier = 0.01F;

		//gravity *= gravityModifier;
		time *= gravityModifier;
		//BallLinearVelocity = gravity * time;
		//origin.Y += BallLinearVelocity * time;

		var Sx = origin.X * MathF.Cos(ToRadian(angle)) * time;
		var Sy = origin.Y * MathF.Sin(ToRadian(angle)) * time - 0.5F * gravity * MathF.Pow(time, 2);

		return origin.Translate(new Vector2(Sx, Sy));
	}

	Vector2 NextPositionX(Vector2 origin, float time, float angle)
	{
		var gravity = -9.80665F;

		var Sx = origin.X * MathF.Cos(ToRadian(angle)) * time;
		var Sy = origin.Y * MathF.Sin(ToRadian(angle)) * time - 0.5F * gravity * MathF.Pow(time, 2);

		return origin.Translate(new Vector2(Sx, Sy));
	}

	Vector2 NextPositionY(Vector2 origin, float instant, float launchAngle, float initialVelocity = 12f)
	{
		origin.X = CalculateHorizontalVelocity(instant, initialVelocity, launchAngle);
		origin.Y = CalculateVerticalVelocity(instant, initialVelocity, launchAngle);
		return origin;
	}

	float CalculateHorizontalVelocity(float instant, float initialVelocity, float launchAngle) => initialVelocity * MathF.Cos(ToRadian(launchAngle)) * instant;
	float CalculateVerticalVelocity(float instant, float initialVelocity, float launchAngle) => initialVelocity * MathF.Sin(ToRadian(launchAngle)) * instant - 0.5F * 9.81F * instant * instant;

	float ToRadian(float angle) => angle * (MathF.PI / 180);
}