﻿using Kz.Engine.DataStructures;

namespace Kz.Engine.Geometry2d.Primitives
{
    public class Circle : IShape
    {
        #region ctor

        public Vector2f Origin;

        public float Radius;

        public Circle()
        {
            Origin = new Vector2f();
            Radius = 0.0f;
        }

        public Circle(Vector2f position, float radius)
        {
            Origin = position;
            Radius = radius;
        }

        public Circle(float x, float y, float radius)
        {
            Origin = new Vector2f(x, y);
            Radius = radius;
        }

        public override string ToString()
        {
            return $"Circle [{Origin}, {Radius}]";
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
            return Geo2dConsts.PI2 * c.Radius;
        }

        public float Circumference() => Circumference(this);

        #endregion Circle Properties
    }
}