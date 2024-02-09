﻿using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class RectangleExtensions
    {
        public static bool Contains(this Rectangle rectangle, Vector2 p) => G2d.Contains(rectangle, p);

        public static bool Contains(this Rectangle rectangle, Line l) => G2d.Contains(rectangle, l);

        public static bool Contains(this Rectangle rectangle, Rectangle r) => G2d.Contains(rectangle, r);

        public static bool Contains(this Rectangle rectangle, Circle c) => G2d.Contains(rectangle, c);

        public static bool Contains(this Rectangle rectangle, Triangle t) => G2d.Contains(rectangle, t);

        public static bool Contains(this Rectangle rectangle, Polygon p) => G2d.Contains(rectangle, p);

        public static List<Vector2> Intersects(this Rectangle rectangle, Vector2 p) => G2d.Intersects(rectangle, p);

        public static List<Vector2> Intersects(this Rectangle rectangle, Line l) => G2d.Intersects(rectangle, l);

        public static List<Vector2> Intersects(this Rectangle rectangle, Rectangle r) => G2d.Intersects(rectangle, r);

        public static List<Vector2> Intersects(this Rectangle rectangle, Circle c) => G2d.Intersects(rectangle, c);

        public static List<Vector2> Intersects(this Rectangle rectangle, Triangle t) => G2d.Intersects(rectangle, t);

        public static List<Vector2> Intersects(this Rectangle rectangle, Polygon p) => G2d.Intersects(rectangle, p);
    }
}
