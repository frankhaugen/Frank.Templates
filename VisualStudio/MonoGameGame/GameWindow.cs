
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Shapes;

using Color = Microsoft.Xna.Framework.Color;

namespace MonoGameGame;

internal class GameWindow : Game
{
    private readonly GraphicsDeviceManager _graphicsDeviceManager;

    public GameWindow() : base()
    {
        _graphicsDeviceManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = nameof(Content);
        IsFixedTimeStep = true;
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
    }

    protected override void Update(GameTime gameTime)
    {

        var spriteBatch = new SpriteBatch(GraphicsDevice);

        //Texture2D pixel;
        //pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
        //pixel.SetData(new[] { Color.White });

        spriteBatch.Begin();

        //var rectangle = new Square(new Vector2(200, 200), 100f, 100f, Color.Chartreuse);

        //rectangle.Draw(GraphicsDevice);

        var center = GraphicsDevice.Viewport.Bounds.Center.ToVector2();

        spriteBatch.DrawCircle(center, 100, 6, Color.Aqua, 5f);

        //GraphicsDevice.Draw(rectangle.GetVertices());

        //spriteBatch.Draw(pixel,
        //    new Vector2(100, 100),
        //    null,
        //    Color.Aqua,
        //    Single.Epsilon,
        //    new Vector2(0, (float)pixel.Height / 2),
        //    new Vector2(100, 100),
        //    SpriteEffects.None,
        //    0);
        spriteBatch.End();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
    }
}