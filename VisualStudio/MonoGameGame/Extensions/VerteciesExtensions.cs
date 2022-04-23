using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGameGame.Models.BasicShapes;

namespace MonoGameGame.Extensions;

internal static class VerteciesExtensions
{
    internal static IReadOnlyList<Vector2> GetVector2s(this Vertices source) => source.GetVector2s();
    internal static IReadOnlyList<Vector3> GetVector3s(this Vertices source) => source.GetVector3s();

    internal static IReadOnlyList<Vector2> GetVector2s(this IEnumerable<VertexPositionColor> source) => source.Select(x => x.Position.ToVector2()).ToList();
    internal static IReadOnlyList<Vector3> GetVector3s(this IEnumerable<VertexPositionColor> source) => source.Select(x => x.Position).ToList();
}