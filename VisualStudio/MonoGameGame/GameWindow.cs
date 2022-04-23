
using Microsoft.Extensions.Options;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Shapes;

using MonoGameGame.Models.BasicShapes;
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
        _sprites = GraphicsDevice.CreateSpriteBatch();
        _spriteFont = Content.Load<SpriteFont>("Text");

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        _sprites.Begin();
        var rectangle = new Rectangle(Center.ToPoint(), new Point(100));
        _sprites.DrawPolygon(Center, rectangle.GetPolygon(), Color.IndianRed);
        _sprites.DrawCircle(Center, 100, 6, Color.Aqua, 5f);
        _sprites.End();
        base.Update(gameTime);
    }

}

public static class GraphicsDeviceExtensions
{
    public static SpriteBatch CreateSpriteBatch(this GraphicsDevice graphicsDevice) => new SpriteBatch(graphicsDevice);
}