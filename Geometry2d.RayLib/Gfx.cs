﻿using Geometry2d.Lib.Primitives;
using Raylib_cs;
using Ray = Geometry2d.Lib.Primitives.Ray;
using Rectangle = Geometry2d.Lib.Primitives.Rectangle;

namespace Geometry2d.RayLib
{
    public static class Gfx
    {
        public static void DrawPoint(Vector2 p, Color color)
        {
            Raylib.DrawPixel((int)p.X, (int)p.Y, color);
        }

        public static void DrawLine(Line line, Color color)
        {
            Raylib.DrawLine((int)line.Start.X, (int)line.Start.Y, (int)line.End.X, (int)line.End.Y, color);
        }

        public static void DrawRay(Ray ray, Color color)
        {
            var end = ray.Direction * 10000.0f;
            Raylib.DrawLine((int)ray.Origin.X, (int)ray.Origin.Y, (int)end.X, (int)end.Y, color);
        }

        public static void DrawRectangle(Rectangle rectangle, Color color)
        {
            Raylib.DrawRectangleLines((int)rectangle.Position.X, (int)rectangle.Position.Y, (int)rectangle.Size.Width, (int)rectangle.Size.Height, color);

            //DrawLine(rectangle.Top, color);
            //DrawLine(rectangle.Bottom, color);
            //DrawLine(rectangle.Left, color);
            //DrawLine(rectangle.Right, color);
        }

        public static void DrawCircle(Circle circle, Color color)
        {
            Raylib.DrawCircleLines((int)circle.Position.X, (int)circle.Position.Y, circle.Radius, color);
        }

        public static void DrawTriangle(Triangle triangle, Color color)
        {
            Raylib.DrawTriangleLines
            (
                new System.Numerics.Vector2(triangle.Vertices[0].X, triangle.Vertices[0].Y),
                new System.Numerics.Vector2(triangle.Vertices[1].X, triangle.Vertices[1].Y),
                new System.Numerics.Vector2(triangle.Vertices[2].X, triangle.Vertices[2].Y),
                color
            );
        }

        public static void DrawPolygon(Polygon polygon, Color color)
        {
            for (var i = 0; i < polygon.Vertices.Count; i++)
            {
                //DrawCircle(
                //    new Circle(polygon.Vertices[i].X, polygon.Vertices[i].Y, 5.0f),
                //    color
                //);

                DrawLine(polygon.Side(i), color);
            }
        }
    }
}