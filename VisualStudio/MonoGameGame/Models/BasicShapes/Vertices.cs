using Microsoft.Xna.Framework.Graphics;

namespace MonoGameGame.Models.BasicShapes;

internal readonly record struct Vertices(VertexPositionColor[] VertexArray, int VertexCount, int[] Indicies, int IndexCount);