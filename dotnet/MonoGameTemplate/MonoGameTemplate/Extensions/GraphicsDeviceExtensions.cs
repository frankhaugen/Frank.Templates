using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameTemplate.Extensions;

public static class GraphicsDeviceExtensions
{
    public static SpriteBatch CreateSpriteBatch(this GraphicsDevice graphicsDevice) => new SpriteBatch(graphicsDevice);
    public static Point GetOrigin(this GraphicsDevice graphicsDevice) => graphicsDevice.Viewport.GetOrigin();
}