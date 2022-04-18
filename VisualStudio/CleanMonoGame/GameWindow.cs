
using Microsoft.Xna.Framework;

namespace CleanMonoGame;

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
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        base.Draw(gameTime);
    }
}