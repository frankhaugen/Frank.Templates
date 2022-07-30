using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Shapes;
using MonoGameTemplate.Models.BasicShapes;

namespace MonoGameTemplate.Extensions;

internal static class SquareExtensions
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
        vertexArray[vertexCount++] = new VertexPositionColor(b.ToVector3(), source.Color);
        vertexArray[vertexCount++] = new VertexPositionColor(c.ToVector3(), source.Color);
        vertexArray[vertexCount++] = new VertexPositionColor(d.ToVector3(), source.Color);

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