﻿namespace Geometry2d.Lib.Primitives
{
    public class Circle : IShape
    {
        #region ctor

        public Vector2 Origin { get; set; }

        public float Radius { get; set; }

        public Circle()
        {
            Origin = new Vector2();
            Radius = 0.0f;
        }

        public Circle(Vector2 position, float radius)
        {
            Origin = position;
            Radius = radius;
        }

        public Circle(float x, float y, float radius)
        {
            Origin = new Vector2(x, y);
            Radius = radius;
        }

        public override string ToString()
        {
            return $"[{Origin}, {Radius}]";
        }

        #endregion ctor

        #region Circle Properties

        public static float Area(Circle c)
        {
            return MathF.PI * c.Radius * c.Radius;
        }

        public float Area() => Area(this);

        public static float Circumference(Circle c)
        {
            return MathF.PI * 2.0f * c.Radius;
        }

        public float Circumference() => Circumference(this);

        #endregion Circle Properties
    }
}