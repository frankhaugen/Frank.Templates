using Microsoft.Xna.Framework;
using MonoGame.Extended.Shapes;

namespace MonoGameTemplate.Extensions;

public static class PolygonExtensions
{
	public static IReadOnlyList<Vector2> GetVector2s(this Polygon source) => source.Vertices;
}