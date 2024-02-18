﻿using Kz.DataStructures;

namespace Geometry2d.Lib.Primitives
{
    public class Line : IShape
    {
        #region ctor

        public Vector2f Start { get; set; }
        public Vector2f End { get; set; }

        public Line()
        {
            Start = new Vector2f();
            End = new Vector2f();
        }

        public Line(float x1, float y1, float x2, float y2)
        {
            Start = new Vector2f(x1, y1);
            End = new Vector2f(x2, y2);
        }

        public Line(Vector2f a, Vector2f b) : this(a.X, a.Y, b.X, b.Y)
        {
        }

        public override string ToString()
        {
            return $"Line [{Start}, {End}]";
        }

        public static bool AreEqual(Line lhs, Line rhs)
        {
            return (Vector2f.AreEqual(lhs.Start, rhs.Start) && Vector2f.AreEqual(lhs.End, rhs.End)) ||
                   (Vector2f.AreEqual(lhs.Start, rhs.End) && Vector2f.AreEqual(lhs.End, rhs.Start));
        }

        public bool AreEqual(Line rhs) => AreEqual(this, rhs);

        #endregion ctor

        #region Line Properties

        /// <summary>
        /// returns a vector pointing from Start to End
        /// </summary>
        public static Vector2f Vector(Line line)
        {
            return line.End - line.Start;
        }

        /// <summary>
        /// returns a vector pointing from Start to End
        /// </summary>
        public Vector2f Vector()
        {
            return End - Start;
        }

        /// <summary>
        /// returns the length of the line
        /// </summary>
        public static float Length(Line line)
        {
            var x = line.End.X - line.Start.X;
            var y = line.End.Y - line.Start.Y;

            return MathF.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// returns the length of the line
        /// </summary>
        public float Length() => Length(this);

        /// <summary>
        /// returns the length squared of the line
        /// </summary>
        public static float Length2(Line line)
        {
            var x = line.End.X - line.Start.X;
            var y = line.End.Y - line.Start.Y;

            return (x * x) + (y * y);
        }

        /// <summary>
        /// returns the length squared of the line
        /// </summary>
        public float Length2() => Length2(this);

        /// <summary>
        /// given a real distance, get a point along the line (distance is percent along the line, e.g. 0.5 would be middle)
        /// </summary>
        public static Vector2f RealPoint(Line line, float distance)
        {
            return line.Start + Vector(line).Normal() * distance;
        }

        /// <summary>
        /// given a real distance, get a point along the line
        /// </summary>
        public Vector2f RealPoint(float distance) => RealPoint(this, distance);

        /// <summary>
        /// returns the middle point of a line
        /// </summary>
        public static Vector2f Middle(Line line) => UnitPoint(line, 0.5f);

        /// <summary>
        /// returns the middle point of a line
        /// </summary>
        public Vector2f Middle() => Middle(this);

        /// <summary>
        /// given a unit distance, get a point along the line (1 unit = length of line)
        /// </summary>
        public static Vector2f UnitPoint(Line line, float distance)
        {
            return line.Start + Vector(line) * distance;
        }

        /// <summary>
        /// given a unit distance, get a point along the line
        /// </summary>
        public Vector2f UnitPoint(float distance) => UnitPoint(this, distance);

        /// <summary>
        /// return lne equation "mx + a" coefficients where: x = m and y = a
        /// returns float.PositiveInfinity if line is vertical
        /// </summary>
        public static Vector2f Coefficients(Line line)
        {
            // check if line is close to vertical
            if (MathF.Abs(line.Start.X - line.End.X) < Consts.EPSILON)
            {
                return new Vector2f(float.PositiveInfinity, float.PositiveInfinity);
            }

            float m = (line.End.Y - line.Start.Y) / (line.End.X - line.Start.X);
            float a = -m * line.Start.X + line.Start.Y;
            return new Vector2f(m, a);
        }

        /// <summary>
        /// return lne equation "mx + a" coefficients where: x = m and y = a
        /// returns float.PositiveInfinity if line is vertical
        /// </summary>
        public Vector2f Coefficients() => Coefficients(this);

        public static List<Vector2f> Endpoints(Line line) => new List<Vector2f> { line.Start, line.End };

        public List<Vector2f> Endpoints() => Endpoints(this);

        #endregion Line Properties
    }
}