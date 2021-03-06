using Microsoft.Xna.Framework;

namespace CleanMonoGame;

internal interface IGameWindow
{
    void Initialize();
    void LoadContent();
    void UnloadContent();
    void Update(GameTime gameTime);
    void Draw(GameTime gameTime);
}