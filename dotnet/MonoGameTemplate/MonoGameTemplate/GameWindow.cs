using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Shapes;
using MonoGameTemplate.Extensions;
using MonoGameTemplate.Models.Configuration;

namespace MonoGameTemplate;

internal class GameWindow : Game, IGameWindow
{
    private readonly IOptions<GameOptions> _gameOptions;
	private readonly ILogger<GameWindow> _logger;

	public Vector2 Center { get; private set; }
    public Game Game => this;

    private SpriteBatch _sprites;
    private SpriteFont _spriteFont;

    public GameWindow(IOptions<GameOptions> gameOptions, ILogger<GameWindow> logger) : base()
    {
        _gameOptions = gameOptions;
        _logger = logger;
        Content.RootDirectory = nameof(Content);
        IsFixedTimeStep = _gameOptions.Value.FixedTimeStep;
        IsMouseVisible = _gameOptions.Value.ShowPointer;
        Window.AllowUserResizing = _gameOptions.Value.AllowUserResizing;
        Window.ClientSizeChanged += (_, _) => Center = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
    }

    protected override void LoadContent()
    {
        Center = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
        _sprites = GraphicsDevice.CreateSpriteBatch();
        _spriteFont = Content.Load<SpriteFont>("Text");

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
		if (Keyboard.GetState().IsKeyDown(Keys.Escape))
		{
			Exit();
		}
		if (Keyboard.GetState().IsKeyDown(Keys.A))
		{
			_logger.LogInformation((int)Keys.A, nameof(Keys.A));
		}

		_sprites.Begin();
        _sprites.DrawPolygon(
            Center,
            new Rectangle(Point.Zero, new Point(50, 50)).GetPolygon(),
            Color.IndianRed);
		
        _sprites.DrawString(_spriteFont, "This is some text", GraphicsDevice.GetOrigin().ToVector2(), Color.Aqua);
        _sprites.End();
        base.Update(gameTime);
    }
}