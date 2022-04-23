using Microsoft.Xna.Framework;

namespace MonoGameGame.Extensions;

internal static class Vector2Extensions
{
    internal static Point ToPoint(this Vector2 source) => new Point(Convert.ToInt32(source.X), Convert.ToInt32(source.Y));
    internal static Vector3 ToVector3(this Vector2 source) => new Vector3(source, 0);
    internal static IReadOnlyList<Vector3> ToVector3s(this IEnumerable<Vector2> source) => new List<Vector3>(source.Select(x => x.ToVector3()));
}