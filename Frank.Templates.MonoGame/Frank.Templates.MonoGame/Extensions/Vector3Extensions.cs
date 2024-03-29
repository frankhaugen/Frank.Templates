﻿using Microsoft.Xna.Framework;

namespace Frank.Templates.MonoGame.Extensions;

internal static class Vector3Extensions
{
    internal static Vector2 ToVector2(this Vector3 source) => new(source.X, source.Y);
    internal static IReadOnlyList<Vector2> ToVector2s(this IEnumerable<Vector3> source) => new List<Vector2>(source.Select(x => x.ToVector2()));
}