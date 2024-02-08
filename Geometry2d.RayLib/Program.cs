﻿// https://www.raylib.com/
// https://github.com/ChrisDill/Raylib-cs
// dotnet add package Raylib-cs

using Geometry2d.Lib.Extensions;
using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;
using Geometry2d.RayLib;
using Raylib_cs;
using Color = Raylib_cs.Color;
using Ray = Geometry2d.Lib.Primitives.Ray;
using Rectangle = Geometry2d.Lib.Primitives.Rectangle;

internal class Program
{
    public static void Main()
    {
        //var triangle = new Triangle(
        //    700.0f, 50.0f,
        //    900.0f, 300.0f,
        //    550.0f, 450.0f);

        //var poly = new Polygon(
        //    new Vector2(50.0f, 50.0f),
        //    new Vector2(200.0f, 100.0f),
        //    new Vector2(250.0f, 250.0f),
        //    new Vector2(100.0f, 250.0f),
        //    new Vector2(150.0f, 175.0f),
        //    new Vector2(25.0f, 90.0f));

        var mouse = new Vector2();

        var p = new Vector2(50.0f, 50.0f);
        var l = new Line(10.0f, 10.0f, 75.0f, 150.0f);
        var r = new Rectangle(20.0f, 20.0f, 200.0f, 80.0f);
        var c = new Circle(200.0f, 200.0f, 35.0f);
        var ray = new Ray(new Vector2(240.0f, 10.0f), new Vector2(-5.0f, 5.0f).Normal());
        var t = new Triangle(130.0f, 150.0f, 160.0f, 240.0f, 25.0f, 245.0f);

        //
        // Initialization
        //
        const int screenWidth = 1024;
        const int screenHeight = 1024;
        const int screenScale = 4;

        Raylib.InitWindow(screenWidth, screenHeight, ".: Geometry 2D :.");
        Raylib.SetTargetFPS(60);

        var target = Raylib.LoadRenderTexture(screenWidth / screenScale, screenHeight / screenScale);

        //
        // MAIN RENDER LOOP
        //
        while (!Raylib.WindowShouldClose())    // Detect window close button or ESC key
        {
            //
            // Process Inputs
            //

            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                // do something...
                Console.WriteLine($"mouse: {mouse}");
            }

            //
            // Update
            //

            // update mouse shape coords
            mouse.X = Raylib.GetMousePosition().X / screenScale;
            mouse.Y = Raylib.GetMousePosition().Y / screenScale;

            //
            // Draw
            //

            #region Draw To Target Texture

            Raylib.BeginTextureMode(target);
            Raylib.ClearBackground(Color.Black);
                                    
            Gfx.DrawPoint(mouse, Color.RayWhite);

            Gfx.DrawPoint(p, p.Contains(mouse) ? Color.Red : Color.RayWhite);
            Gfx.DrawLine(l, l.Contains(mouse) ? Color.Red : Color.RayWhite);
            Gfx.DrawRectangle(r, r.Contains(mouse) ? Color.Red : Color.RayWhite);
            Gfx.DrawCircle(c, c.Contains(mouse) ? Color.Red : Color.RayWhite);
            Gfx.DrawRay(ray, ray.Contains(mouse) ? Color.Red : Color.RayWhite);
            Gfx.DrawTriangle(t, t.Contains(mouse) ? Color.Red : Color.RayWhite);

            Raylib.EndTextureMode();

            #endregion Draw To Target Texture

            #region Draw Target Texture to Window

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            var src = new Raylib_cs.Rectangle(0, 0, target.Texture.Width, -target.Texture.Height);
            var dest = new Raylib_cs.Rectangle(0, 0, screenWidth, screenHeight);
            Raylib.DrawTexturePro(
                target.Texture,
                src,
                dest,
                new System.Numerics.Vector2(0.0f, 0.0f),
                0,
                Color.White);

            Raylib.EndDrawing();

            #endregion Draw Target Texture to Window
        }

        //
        // De-Initialization
        //

        Raylib.CloseWindow();        // Close window and OpenGL context
    }
}