using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Frank.Templates.MonoGame.Extensions;

public static class ViewportExtensions
{
    public static Point GetOrigin(this Viewport source) => source.Bounds.Location;
}