using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameTemplate.Extensions;

public static class ViewportExtensions
{
    public static Point GetOrigin(this Viewport source) => source.Bounds.Location;
}