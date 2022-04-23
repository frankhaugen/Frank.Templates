using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Shapes;

namespace MonoGameGame.Models.BasicShapes;

internal readonly record struct Triangle(VertexPosition A, VertexPosition B, VertexPosition C, Color Color);
internal readonly record struct Square(Vector2 Position, float Width, float Height, Color Color);
internal readonly record struct Vertices(VertexPositionColor[] VertexArray, int VertexCount, int[] Indicies, int IndexCount);

internal static class VerteciesExtentions
{
    internal static IReadOnlyList<Vector2> GetVector2s(this Vertices source) => source.GetVector2s();
    internal static IReadOnlyList<Vector3> GetVector3s(this Vertices source) => source.GetVector3s();

    internal static IReadOnlyList<Vector2> GetVector2s(this IEnumerable<VertexPositionColor> source) => source.Select(x => x.Position.ToVector2()).ToList();
    internal static IReadOnlyList<Vector3> GetVector3s(this IEnumerable<VertexPositionColor> source) => source.Select(x => x.Position).ToList();
}

internal static class RectangleExtentions
{
    internal static IReadOnlyList<Vector2> GetVector2s(this Rectangle source)
    {
        var vectors = new List<Vector2>();
        vectors.Add(new Vector2(source.Left, source.Top));
        vectors.Add(new Vector2(source.Right, source.Top));
        vectors.Add(new Vector2(source.Right, source.Bottom));
        vectors.Add(new Vector2(source.Left, source.Bottom));
        return vectors;
    }

    internal static Polygon GetPolygon(this Rectangle source) => new(source.GetVector2s());
}

internal static class SquareExtentions
{
    internal static Polygon GetPolygon(this Square source) => new Polygon(source.GetVertices().GetVector2s());

    internal static Vertices GetVertices(this Square source)
    {
        var vertexArray = new VertexPositionColor[4];
        var indicies = new int[6];
        var indexCount = 0;
        var vertexCount = 0;

        var left = source.Position.X;
        var right = source.Position.X + source.Width;
        var bottom = source.Position.Y;
        var top = source.Position.Y + source.Height;

        var a = new Vector2(left, top);
        var b = new Vector2(right, top);
        var c = new Vector2(right, bottom);
        var d = new Vector2(left, bottom);

        indicies[indexCount++] = 0 + vertexCount;
        indicies[indexCount++] = 1 + vertexCount;
        indicies[indexCount++] = 2 + vertexCount;
        indicies[indexCount++] = 0 + vertexCount;
        indicies[indexCount++] = 2 + vertexCount;
        indicies[indexCount++] = 3 + vertexCount;

        vertexArray[vertexCount++] = new VertexPositionColor(a.ToVector3(), source.Color);
        vertexArray[vertexCount++] = (new VertexPositionColor(b.ToVector3(), source.Color));
        vertexArray[vertexCount++] = (new VertexPositionColor(c.ToVector3(), source.Color));
        vertexArray[vertexCount++] = (new VertexPositionColor(d.ToVector3(), source.Color));

        return new Vertices(vertexArray, vertexCount, indicies, indexCount);
    }

    internal static void Draw(this GraphicsDevice graphicsDevice, Vertices vertices)
    {
        var effect = new BasicEffect(graphicsDevice);
        var viewport = graphicsDevice.Viewport;

        effect.TextureEnabled = true;
        effect.FogEnabled = false;
        effect.LightingEnabled = false;
        effect.VertexColorEnabled = true;
        effect.World = Matrix.Identity;
        effect.View = Matrix.Identity;
        effect.Projection = Matrix.CreateOrthographicOffCenter(0, viewport.Width, 0, viewport.Height, 0, 0);

        foreach (var pass in effect.CurrentTechnique.Passes)
        {
            pass.Apply();

            graphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices.VertexArray, 0, vertices.VertexCount, vertices.Indicies, 0, vertices.IndexCount / 3);
        }
    }
}

internal static class Vector2Extentsions
{
    internal static Point ToPoint(this Vector2 source) => new Point(Convert.ToInt32(source.X), Convert.ToInt32(source.Y));
    internal static Vector3 ToVector3(this Vector2 source) => new Vector3(source, 0);
    internal static IReadOnlyList<Vector3> ToVector3s(this IEnumerable<Vector2> source) => new List<Vector3>(source.Select(x => x.ToVector3()));
}

internal static class Vector3Extentsions
{
    internal static Vector2 ToVector2(this Vector3 source) => new(source.X, source.Y);
    internal static IReadOnlyList<Vector2> ToVector2s(this IEnumerable<Vector3> source) => new List<Vector2>(source.Select(x => x.ToVector2()));
}