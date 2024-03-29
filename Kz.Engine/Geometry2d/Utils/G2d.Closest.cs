﻿using Kz.Engine.Geometry2d.Primitives;
using Kz.Engine.DataStructures;

namespace Kz.Engine.Geometry2d.Utils
{
    public static partial class G2d
    {
        #region IShape CLOSEST IShape

        public static Vector2f Closest(IShape lhs, IShape rhs)
        {
            return lhs switch
            {
                Vector2f v => rhs switch
                {
                    Vector2f v2 => Closest(v, v2),
                    Line l2 => Closest(v, l2),
                    Rectangle r2 => Closest(v, r2),
                    Circle c2 => Closest(v, c2),
                    Triangle t2 => Closest(v, t2),
                    Polygon poly2 => Closest(v, poly2),
                    Ray ray2 => Closest(v, ray2),
                    _ => new Vector2f(),
                },
                Line l => rhs switch
                {
                    Vector2f v2 => Closest(l, v2),
                    Line l2 => Closest(l, l2),
                    Rectangle r2 => Closest(l, r2),
                    Circle c2 => Closest(l, c2),
                    Triangle t2 => Closest(l, t2),
                    Polygon poly2 => Closest(l, poly2),
                    Ray ray2 => Closest(l, ray2),
                    _ => new Vector2f(),
                },
                Rectangle r => rhs switch
                {
                    Vector2f v2 => Closest(r, v2),
                    Line l2 => Closest(r, l2),
                    Rectangle r2 => Closest(r, r2),
                    Circle c2 => Closest(r, c2),
                    Triangle t2 => Closest(r, t2),
                    Polygon poly2 => Closest(r, poly2),
                    Ray ray2 => Closest(r, ray2),
                    _ => new Vector2f(),
                },
                Circle c => rhs switch
                {
                    Vector2f v2 => Closest(c, v2),
                    Line l2 => Closest(c, l2),
                    Rectangle r2 => Closest(c, r2),
                    Circle c2 => Closest(c, c2),
                    Triangle t2 => Closest(c, t2),
                    Polygon poly2 => Closest(c, poly2),
                    Ray ray2 => Closest(c, ray2),
                    _ => new Vector2f(),
                },
                Triangle t => rhs switch
                {
                    Vector2f v2 => Closest(t, v2),
                    Line l2 => Closest(t, l2),
                    Rectangle r2 => Closest(t, r2),
                    Circle c2 => Closest(t, c2),
                    Triangle t2 => Closest(t, t2),
                    Polygon poly2 => Closest(t, poly2),
                    Ray ray2 => Closest(t, ray2),
                    _ => new Vector2f(),
                },
                Polygon poly => rhs switch
                {
                    Vector2f v2 => Closest(poly, v2),
                    Line l2 => Closest(poly, l2),
                    Rectangle r2 => Closest(poly, r2),
                    Circle c2 => Closest(poly, c2),
                    Triangle t2 => Closest(poly, t2),
                    Polygon poly2 => Closest(poly, poly2),
                    Ray ray2 => Closest(poly, ray2),
                    _ => new Vector2f(),
                },
                Ray ray => rhs switch
                {
                    Vector2f v2 => Closest(ray, v2),
                    Line l2 => Closest(ray, l2),
                    //Rectangle r2 => Closest(ray, r2),
                    //Circle c2 => Closest(ray, c2),
                    //Triangle t2 => Closest(ray, t2),
                    //Polygon poly2 => Closest(ray, poly2),
                    //Ray ray2 => Closest(ray, ray2),
                    _ => new Vector2f(),
                },
                _ => new Vector2f(),
            };
        }

        #endregion IShape CLOSEST IShape

        #region [Shape] CLOSEST Vector2f

        /// <summary>
        /// Return the closest point on a point to a point
        /// </summary>
        public static Vector2f Closest(Vector2f lhs, Vector2f rhs)
        {
            return rhs;
        }

        /// <summary>
        /// Return the closest point on a point to a line
        /// </summary>
        public static Vector2f Closest(Line lhs, Vector2f rhs)
        {
            return rhs;
        }

        /// <summary>
        /// Return the closest point on a point to a rectangle
        /// </summary>
        public static Vector2f Closest(Rectangle lhs, Vector2f rhs)
        {
            return rhs;
        }

        /// <summary>
        /// Return the closest point on a point to a circle
        /// </summary>
        public static Vector2f Closest(Circle lhs, Vector2f rhs)
        {
            return rhs;
        }

        /// <summary>
        /// Return the closest point on a point to a triangle
        /// </summary>
        public static Vector2f Closest(Triangle lhs, Vector2f rhs)
        {
            return rhs;
        }

        /// <summary>
        /// Return the closest point on a point to a polygon
        /// </summary>
        public static Vector2f Closest(Polygon lhs, Vector2f rhs)
        {
            return rhs;
        }

        /// <summary>
        /// Return the closest point on a ray to a ray
        /// </summary>
        public static Vector2f Closest(Ray lhs, Vector2f rhs)
        {
            return rhs;
        }

        #endregion [Shape] CLOSEST Vector2f

        #region [Shape] CLOSEST Line

        /// <summary>
        /// Return the closest point on a Line to a point
        /// </summary>
        public static Vector2f Closest(Vector2f lhs, Line rhs)
        {
            var ab = rhs.End - rhs.Start;
            var ap = lhs - rhs.Start;

            var abApDot = ab.Dot(ap);
            var abAbDot = ab.Dot(ab);
            var t = abApDot / abAbDot;

            if (t < 0) return rhs.Start;
            if (t > 1) return rhs.End;

            var closest = rhs.Start + (t * ab);
            return closest;
        }

        /// <summary>
        /// Return the closest point on a Line (rhs) to a line (lhs)
        /// </summary>
        public static Vector2f Closest(Line lhs, Line rhs)
        {
            // check for intersection
            var intersections = Intersects(lhs, rhs);
            if (intersections.Any()) return intersections[0];

            // get closest point on line to start and end
            var p1 = Closest(lhs.Start, rhs);
            var p2 = Closest(lhs.End, rhs);

            var p3 = rhs.Start;
            var p4 = rhs.End;

            // calculate lenghths of closest point with the start and end
            var d1 = (lhs.Start - p1).Magnitude();
            var d2 = (lhs.End - p2).Magnitude();

            var d3 = DistanceTo(p3, lhs);
            var d4 = DistanceTo(p4, lhs);

            // return the closest one
            var min = MathF.Min(MathF.Min(d1, d2), MathF.Min(d3, d4));
            var closest = min == d1 ? p1 :
                          min == d2 ? p2 :
                          min == d3 ? p3 : p4;

            return closest;
        }

        /// <summary>
        /// Return the closest point on a Line to a rectangle
        /// </summary>
        public static Vector2f Closest(Rectangle lhs, Line rhs)
        {
            // check if any endpoints are in the rectangle...if yes, that's the closest point
            if (Contains(lhs, rhs.Start)) return rhs.Start;
            if (Contains(lhs, rhs.End)) return rhs.End;

            // check intersections
            var intersections = Intersects(lhs, rhs);
            if (intersections.Any()) return intersections.First();

            var minDistance = float.MaxValue;
            var closestPoint = new Vector2f();

            // calculate the closest points from the rectangles corners to the line
            foreach (var corner in lhs.Vertices)
            {
                var point = Closest(corner, rhs);
                var dist = (point - corner).Magnitude();
                if (dist < minDistance)
                {
                    minDistance = dist;
                    closestPoint = point;
                }
            }

            // check if the line's endpoints are closer to the rectangle
            foreach (var endpoint in rhs.Endpoints())
            {
                var dist = MathF.Min
                (
                    MathF.Min(DistanceTo(endpoint, lhs.Top), DistanceTo(endpoint, lhs.Right)),
                    MathF.Min(DistanceTo(endpoint, lhs.Bottom), DistanceTo(endpoint, lhs.Left))
                );
                if (dist < minDistance)
                {
                    minDistance = dist;
                    closestPoint = endpoint;
                }
            }

            return closestPoint;
        }

        /// <summary>
        /// Return the closest point on a Line to a circle
        /// </summary>
        public static Vector2f Closest(Circle lhs, Line rhs)
        {
            var point = Closest(rhs, lhs);
            return Closest(point, rhs);
        }

        /// <summary>
        /// Return the closest point on a Line to a triangle
        /// </summary>
        public static Vector2f Closest(Triangle lhs, Line rhs)
        {
            return Closest(lhs, lhs.Sides, rhs);
        }

        /// <summary>
        /// Return the closest point on a Line to a polygon
        /// </summary>
        public static Vector2f Closest(Polygon lhs, Line rhs)
        {
            return Closest(lhs, lhs.Sides(), rhs);
        }

        /// <summary>
        /// Return the closest point on a Line to a ray
        /// </summary>
        public static Vector2f Closest(Ray lhs, Line rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            // closest point on the line segment to the ray origin
            var p1 = Closest(lhs.Origin, rhs);
            var d1 = (p1 - lhs.Origin).Magnitude2();

            //closest points on the ray to the line endpoints
            var p2 = Closest(rhs.Start, lhs);
            var d2 = (p2 - rhs.Start).Magnitude2();

            var p3 = Closest(rhs.End, lhs);
            var d3 = (p3 - rhs.End).Magnitude2();

            // compare distances
            var min = MathF.Min(d1, MathF.Min(d2, d3));
            var closest = min == d1 ? p1 :
                          min == d2 ? rhs.Start : rhs.End;

            return closest;
        }

        #endregion [Shape] CLOSEST Line

        #region [Shape] CLOSEST Rectangle

        /// <summary>
        /// Return the closest point on a Rectangle to a Vector2f
        /// </summary>
        public static Vector2f Closest(Vector2f lhs, Rectangle rhs)
        {
            var closest = Closest(lhs, rhs.Sides);
            return closest.Vector2f;
        }

        /// <summary>
        /// Return the closest point on a Rectangle to a Line
        /// </summary>
        public static Vector2f Closest(Line lhs, Rectangle rhs)
        {
            // check for intersections
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            var closestPoint = new Vector2f();
            var min = float.MaxValue;

            foreach (var endpoint in lhs.Endpoints())
            {
                foreach (var side in rhs.Sides)
                {
                    var closest = Closest(endpoint, side);
                    var dist = DistanceTo(endpoint, side);
                    if (dist < min)
                    {
                        min = dist;
                        closestPoint = closest;
                    }
                }
            }

            foreach (var corner in rhs.Vertices)
            {
                var dist = DistanceTo(corner, lhs);
                if (dist < min)
                {
                    min = dist;
                    closestPoint = corner;
                }
            }

            return closestPoint;
        }

        /// <summary>
        /// Return the closest point on a Rectangle to a Rectangle
        /// </summary>
        public static Vector2f Closest(Rectangle lhs, Rectangle rhs)
        {
            return Closest(lhs, rhs, lhs.Sides, rhs.Sides);
        }

        /// <summary>
        /// Return the closest point on a Rectangle to a Circle
        /// </summary>
        public static Vector2f Closest(Circle lhs, Rectangle rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            return Closest(lhs.Origin, rhs);
        }

        /// <summary>
        /// Return the closest point on a Rectangle to a Triangle
        /// </summary>
        public static Vector2f Closest(Triangle lhs, Rectangle rhs)
        {
            return Closest(lhs, rhs, lhs.Sides, rhs.Sides);
        }

        /// <summary>
        /// Return the closest point on a Rectangle to a Polygon
        /// </summary>
        public static Vector2f Closest(Polygon lhs, Rectangle rhs)
        {
            return Closest(lhs, rhs, lhs.Sides(), rhs.Sides);
        }

        /// <summary>
        /// Return the closest point on a Rectangle to a Ray
        /// </summary>
        public static Vector2f Closest(Ray lhs, Rectangle rhs)
        {
            throw new NotImplementedException("Closest(Ray lhs, Rectangle rhs)");
        }

        #endregion [Shape] CLOSEST Rectangle

        #region [Shape] CLOSEST Circle

        /// <summary>
        /// Return the closest point on a Circle to a Vector2f
        /// </summary>
        public static Vector2f Closest(Vector2f lhs, Circle rhs)
        {
            var v = (lhs - rhs.Origin).Normal() * rhs.Radius;
            var closest = rhs.Origin + v;
            return closest;
        }

        /// <summary>
        /// Return the closest point on a Circle to a Line
        /// </summary>
        public static Vector2f Closest(Line lhs, Circle rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            var point = Closest(rhs.Origin, lhs);
            return rhs.Origin + ((point - rhs.Origin).Normal() * rhs.Radius);
        }

        /// <summary>
        /// Return the closest point on a Circle to a Rectangle
        /// </summary>
        public static Vector2f Closest(Rectangle lhs, Circle rhs)
        {
            return Closest(lhs, lhs.Sides, rhs);
        }

        /// <summary>
        /// Return the closest point on a Circle to a Circle
        /// </summary>
        public static Vector2f Closest(Circle lhs, Circle rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            return Closest(lhs.Origin, rhs);
        }

        /// <summary>
        /// Return the closest point on a Circle to a Triangle
        /// </summary>
        public static Vector2f Closest(Triangle lhs, Circle rhs)
        {
            return Closest(lhs, lhs.Sides, rhs);
        }

        /// <summary>
        /// Return the closest point on a Circle to a Polygon
        /// </summary>
        public static Vector2f Closest(Polygon lhs, Circle rhs)
        {
            return Closest(lhs, lhs.Sides(), rhs);
        }

        /// <summary>
        /// Return the closest point on a Circle to a Ray
        /// </summary>
        public static Vector2f Closest(Ray lhs, Circle rhs)
        {
            throw new NotImplementedException("Closest(Ray lhs, Circle rhs)");
        }

        #endregion [Shape] CLOSEST Circle

        #region [Shape] CLOSEST Triangle

        /// <summary>
        /// Return the closest point on a Triangle to a Vector2f
        /// </summary>
        public static Vector2f Closest(Vector2f lhs, Triangle rhs)
        {
            var closest = Closest(lhs, rhs.Sides);
            return closest.Vector2f;
        }

        /// <summary>
        /// Return the closest point on a Triangle to a Line
        /// </summary>
        public static Vector2f Closest(Line lhs, Triangle rhs)
        {
            // check intersections
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            var closestPoint = new Vector2f();
            var min = float.MaxValue;

            foreach (var side in rhs.Sides)
            {
                foreach (var endpoint in lhs.Endpoints())
                {
                    var closest = Closest(endpoint, side);
                    var dist = DistanceTo(endpoint, side);
                    if (dist < min)
                    {
                        min = dist;
                        closestPoint = closest;
                    }
                }
            }

            foreach (var corner in rhs.Vertices)
            {
                var dist = DistanceTo(corner, lhs);
                if (dist < min)
                {
                    min = dist;
                    closestPoint = corner;
                }
            }

            return closestPoint;
        }

        /// <summary>
        /// Return the closest point on a Triangle to a Rectangle
        /// </summary>
        public static Vector2f Closest(Rectangle lhs, Triangle rhs)
        {
            return Closest(lhs, rhs, lhs.Sides, rhs.Sides);
        }

        /// <summary>
        /// Return the closest point on a Triangle to a Circle
        /// </summary>
        public static Vector2f Closest(Circle lhs, Triangle rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            return Closest(lhs.Origin, rhs);
        }

        /// <summary>
        /// Return the closest point on a Triangle to a Triangle
        /// </summary>
        public static Vector2f Closest(Triangle lhs, Triangle rhs)
        {
            return Closest(lhs, rhs, lhs.Sides, rhs.Sides);
        }

        /// <summary>
        /// Return the closest point on a Triangle to a Polygon
        /// </summary>
        public static Vector2f Closest(Polygon lhs, Triangle rhs)
        {
            return Closest(lhs, rhs, lhs.Sides(), rhs.Sides);
        }

        /// <summary>
        /// Return the closest point on a Triangle to a Ray
        /// </summary>
        public static Vector2f Closest(Ray lhs, Triangle rhs)
        {
            throw new NotImplementedException("Closest(Ray lhs, Triangle rhs)");
        }

        #endregion [Shape] CLOSEST Triangle

        #region [Shape] CLOSEST Polygon

        /// <summary>
        /// Return the closest point on a Polygon to a Vector2f
        /// </summary>
        public static Vector2f Closest(Vector2f lhs, Polygon rhs)
        {
            var closest = Closest(lhs, rhs.Sides());
            return closest.Vector2f;
        }

        /// <summary>
        /// Return the closest point on a Polygon to a Line
        /// </summary>
        public static Vector2f Closest(Line lhs, Polygon rhs)
        {
            // check intersections
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            var closestPoint = new Vector2f();
            var min = float.MaxValue;

            foreach (var side in rhs.Sides())
            {
                foreach (var endpoint in lhs.Endpoints())
                {
                    var closest = Closest(endpoint, side);
                    var dist = DistanceTo(endpoint, side);
                    if (dist < min)
                    {
                        min = dist;
                        closestPoint = closest;
                    }
                }
            }

            foreach (var corner in rhs.Vertices)
            {
                var dist = DistanceTo(corner, lhs);
                if (dist < min)
                {
                    min = dist;
                    closestPoint = corner;
                }
            }

            return closestPoint;
        }

        /// <summary>
        /// Return the closest point on a Polygon to a Rectangle
        /// </summary>
        public static Vector2f Closest(Rectangle lhs, Polygon rhs)
        {
            return Closest(lhs, rhs, lhs.Sides, rhs.Sides());
        }

        /// <summary>
        /// Return the closest point on a Polygon to a Circle
        /// </summary>
        public static Vector2f Closest(Circle lhs, Polygon rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            return Closest(lhs.Origin, rhs);
        }

        /// <summary>
        /// Return the closest point on a Polygon to a Triangle
        /// </summary>
        public static Vector2f Closest(Triangle lhs, Polygon rhs)
        {
            return Closest(lhs, rhs, lhs.Sides, rhs.Sides());
        }

        /// <summary>
        /// Return the closest point on a Polygon to a Polygon
        /// </summary>
        public static Vector2f Closest(Polygon lhs, Polygon rhs)
        {
            return Closest(lhs, rhs, lhs.Sides(), rhs.Sides());
        }

        /// <summary>
        /// Return the closest point on a Polygon to a Ray
        /// </summary>
        public static Vector2f Closest(Ray lhs, Polygon rhs)
        {
            throw new NotImplementedException("Closest(Ray lhs, Polygon rhs)");
        }

        #endregion [Shape] CLOSEST Polygon

        #region [Shape] CLOSEST Ray

        /// <summary>
        /// Return the closest point on a Ray to a Vector2f
        /// </summary>
        public static Vector2f Closest(Vector2f lhs, Ray rhs)
        {
            var rayPoint = lhs - rhs.Origin;

            var rayPointDotDirection = rayPoint.Dot(rhs.Direction);
            var directionDotDirection = rhs.Direction.Dot(rhs.Direction);

            var t = rayPointDotDirection / directionDotDirection;

            if (t < 0) t = 0; // closest point is ray origin

            var closest = rhs.Origin + (t * rhs.Direction);
            return closest;
        }

        /// <summary>
        /// Return the closest point on a Ray to a Line
        /// </summary>
        public static Vector2f Closest(Line lhs, Ray rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            var start = Closest(lhs.Start, rhs);
            var startDist = (lhs.Start - start).Magnitude2();

            var end = Closest(lhs.End, rhs);
            var endDist = (lhs.End - end).Magnitude2();

            var side = Closest(rhs.Origin, lhs);
            var sideDist = (side - rhs.Origin).Magnitude2();

            var min = MathF.Min(startDist, MathF.Min(endDist, sideDist));
            var closest = min == startDist ? start :
                          min == endDist ? end : rhs.Origin;
            return closest;
        }

        /// <summary>
        /// Return the closest point on a Ray to a Rectangle
        /// </summary>
        public static Vector2f Closest(Rectangle lhs, Ray rhs)
        {
            return Closest(lhs, lhs.Sides, rhs);
        }

        /// <summary>
        /// Return the closest point on a Ray to a Circle
        /// </summary>
        public static Vector2f Closest(Circle lhs, Ray rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            return Closest(lhs.Origin, rhs);
        }

        /// <summary>
        /// Return the closest point on a Ray to a Triangle
        /// </summary>
        public static Vector2f Closest(Triangle lhs, Ray rhs)
        {
            return Closest(lhs, lhs.Sides, rhs);
        }

        /// <summary>
        /// Return the closest point on a Ray to a Polygon
        /// </summary>
        public static Vector2f Closest(Polygon lhs, Ray rhs)
        {
            return Closest(lhs, lhs.Sides(), rhs);
        }

        /// <summary>
        /// Return the closest point on a Ray to a Ray
        /// </summary>
        public static Vector2f Closest(Ray lhs, Ray rhs)
        {
            throw new NotImplementedException("Closest(Ray lhs, Ray rhs)");
        }

        #endregion [Shape] CLOSEST Ray

        #region Helpers

        /// <summary>
        /// Return the closest point on a line and closest line to a point (lhs) from a list of lines (rhs)
        /// </summary>
        public static (Vector2f Vector2f, Line Line) Closest(Vector2f lhs, List<Line> rhs)
        {
            var minDistance = float.MaxValue;
            Line? closestLine = null;
            Vector2f closestPoint = Vector2f.Zero;

            foreach (var line in rhs)
            {
                var closestPointOnLine = Closest(lhs, line);
                var distance = (closestPointOnLine - lhs).Magnitude2();
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestLine = line;
                    closestPoint = closestPointOnLine;
                }
            }

            return (closestPoint, closestLine!);
        }

        /// <summary>
        /// Returns the closest point on shape RHS to shape LHS
        /// </summary>
        public static Vector2f Closest(IShape lhs, IShape rhs, List<Line> lhsSides, List<Line> rhsSides)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            var min = float.MaxValue;
            var closestPoint = new Vector2f();

            foreach (var s1 in lhsSides)
            {
                foreach (var s2 in rhsSides)
                {
                    var point = Closest(s1, s2);
                    var dist = DistanceTo(point, s1);
                    if (dist < min)
                    {
                        min = dist;
                        closestPoint = point;
                    }
                }
            }

            return closestPoint;
        }

        /// <summary>
        /// Returns the closest point on a line to a IShape lhs
        /// </summary>
        public static Vector2f Closest(IShape lhs, List<Line> lhsSides, Line rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            var min = float.MaxValue;
            var closestPoint = new Vector2f();

            foreach (var s1 in lhsSides)
            {
                var point = Closest(s1, rhs);
                var dist = DistanceTo(point, s1);
                if (dist < min)
                {
                    min = dist;
                    closestPoint = point;
                }
            }

            return closestPoint;
        }

        /// <summary>
        /// Returns the closest point on a circle to a IShape lhs
        /// </summary>
        public static Vector2f Closest(IShape lhs, List<Line> lhsSides, Circle rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            var min = float.MaxValue;
            var closestPoint = new Vector2f();

            foreach (var side in lhsSides)
            {
                var point = Closest(side, rhs);
                var dist = DistanceTo(point, side);
                if (dist < min)
                {
                    min = dist;
                    closestPoint = point;
                }
            }

            return closestPoint;
        }

        /// <summary>
        /// Returns the closest point on a ray to a IShape lhs
        /// </summary>
        public static Vector2f Closest(IShape lhs, List<Line> lhsSides, Ray rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            var min = float.MaxValue;
            var closestPoint = new Vector2f();

            foreach (var side in lhsSides)
            {
                var point = Closest(side, rhs);
                var dist = DistanceTo(point, side);
                if (dist < min)
                {
                    min = dist;
                    closestPoint = point;
                }
            }

            return closestPoint;
        }

        #endregion Helpers
    }
}