using Microsoft.Xna.Framework.Graphics;

namespace MonoGameTemplate.Models.BasicShapes;

internal readonly record struct Vertices(VertexPositionColor[] VertexArray, int VertexCount, int[] Indicies, int IndexCount);