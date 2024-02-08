﻿using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class PolygonExtensions
    {
        public static bool Contains(this Polygon polygon, Vector2 p) => G2d.Contains(polygon, p);

        public static bool Contains(this Polygon polygon, Line l) => G2d.Contains(polygon, l);

        public static bool Contains(this Polygon polygon, Rectangle r) => G2d.Contains(polygon, r);

        public static bool Contains(this Polygon polygon, Circle c) => G2d.Contains(polygon, c);

        public static bool Contains(this Polygon polygon, Triangle t) => G2d.Contains(polygon, t);

        public static bool Contains(this Polygon polygon, Polygon p) => G2d.Contains(polygon, p);
    }
}
