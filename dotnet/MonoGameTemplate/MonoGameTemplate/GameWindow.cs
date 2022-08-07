using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
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

	public Vector2 Center { get; private set; }
    public Game Game => this;
    
    private SpriteFont _spriteFont;

    public GameWindow(IOptions<GameOptions> gameOptions, ILogger<GameWindow> logger, IOptions<GameState> gameState, IDrawer drawer) : base()
    {
        _gameOptions = gameOptions;
        _logger = logger;
        _gameState = gameState;
        _drawer = drawer;
        Content.RootDirectory = nameof(Content);
        IsFixedTimeStep = _gameOptions.Value.FixedTimeStep;
        IsMouseVisible = _gameOptions.Value.ShowPointer;
        Window.AllowUserResizing = _gameOptions.Value.AllowUserResizing;
        Window.ClientSizeChanged += (_, _) => Center = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
    }

    protected override void LoadContent()
    {
        Center = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
        _spriteFont = Content.Load<SpriteFont>("Text");
        _gameState.Value.SpriteBatch = GraphicsDevice.CreateSpriteBatch(); 
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
	    _gameState.Value.GameTime = gameTime;

		if (Keyboard.GetState().IsKeyDown(Keys.Escape))
		{
			Exit();
		}
		if (Keyboard.GetState().IsKeyDown(Keys.A))
		{
			_logger.LogInformation((int)Keys.A, nameof(Keys.A));
		}

		_drawer.Begin();

		_drawer.DrawPolygon(Center, new Polygon(new List<Vector2>() {Center, new Vector2(0.001f, 0.002f), Vector2.UnitX}), Color.Beige);
        _drawer.DrawPolygon(
            Center,
            new Rectangle(Point.Zero, new Point(50, 50)).GetPolygon(),
            Color.IndianRed);
        _drawer.DrawString(_spriteFont, "This is some text", GraphicsDevice.GetOrigin().ToVector2(), Color.Aqua);

        _drawer.End();
        
        base.Update(gameTime);
    }
}