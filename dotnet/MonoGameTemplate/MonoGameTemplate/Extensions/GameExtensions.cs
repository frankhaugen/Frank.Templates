using Microsoft.Xna.Framework;

namespace MonoGameTemplate.Extensions;

public static class GameExtensions
{
    public static Point GetOrigin(this Game source) => source.GraphicsDevice.GetOrigin();
    public static Point GetCenter(this Game source) => source.GraphicsDevice.Viewport.Bounds.Center;
}