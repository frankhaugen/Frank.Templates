using Microsoft.Xna.Framework.Graphics;

namespace Frank.Templates.MonoGame.Models.BasicShapes;

public readonly record struct Vertices(VertexPositionColor[] VertexArray, int VertexCount, int[] Indicies, int IndexCount);