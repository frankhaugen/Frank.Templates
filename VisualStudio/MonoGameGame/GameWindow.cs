
using Microsoft.Extensions.Options;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Shapes;

using MonoGameGame.Extensions;
using MonoGameGame.Models.Configuration;

namespace MonoGameGame;

internal class GameWindow : Game, IGameWindow
{
    private readonly IOptions<GameOptions> _gameOptions;

    public Vector2 Center { get; private set; }
    public Game Game => this;

    private SpriteBatch _sprites;
    private SpriteFont _spriteFont;

    public GameWindow(IOptions<GameOptions> gameOptions) : base()
    {
        _gameOptions = gameOptions;
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

public static class GraphicsDeviceExtensions
{
    public static SpriteBatch CreateSpriteBatch(this GraphicsDevice graphicsDevice) => new SpriteBatch(graphicsDevice);
    public static Point GetOrigin(this GraphicsDevice graphicsDevice) => graphicsDevice.Viewport.GetOrigin();
}

public static class PolygonExtensions
{
    public static IReadOnlyList<Vector2> GetVector2s(this Polygon source) => source.Vertices;
}

public static class ViewportExtensions
{
    public static Point GetOrigin(this Viewport source) => source.Bounds.Location;
}

public static class GameExtensions
{
    public static Point GetOrigin(this Game source) => source.GraphicsDevice.GetOrigin();
    public static Point GetCenter(this Game source) => source.GraphicsDevice.Viewport.Bounds.Center;
}