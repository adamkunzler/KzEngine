﻿using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class Vector2Extensions
    {
        public static bool Contains(this Vector2 point, Vector2 p) => G2d.Contains(point, p);

        public static List<Vector2> Intersects(this Vector2 point, Vector2 p) => G2d.Intersects(point, p);

        public static List<Vector2> Intersects(this Vector2 point, Line l) => G2d.Intersects(point, l);
    }
}