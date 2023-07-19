using System;
using System.Numerics;
using SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace LiftSimulation;

class Program
{
    static void Main(string[] args)
    {
        Wing wng = new Wing();

        Console.Write("write the mass of the wing: "); wng.Mass=Convert.ToDouble(Console.ReadLine());
        Console.Write("write the area of the wing: "); wng.WingArea = Convert.ToDouble(Console.ReadLine());
        Console.Write("write the airspeed: "); wng.AirSpeed = Convert.ToDouble(Console.ReadLine());
        Console.Write("write the coefficent of lift: "); wng.Coeffecient = Convert.ToDouble(Console.ReadLine());

        // Create the main window
        RenderWindow window = new RenderWindow(new VideoMode(1200, 600), "lift simulation");
        //200pixels = 1 m

        window.SetVerticalSyncEnabled(true);

        window.Closed += (sender, args) => window.Close();
        AirAnimation ar = new AirAnimation();
        ar.Airspeed = Convert.ToInt32(wng.AirSpeed);
        ar.Initilizer();
        wng.lv[0] = new Vertex(new Vector2f(100, 100));
        wng.lv[1] = new Vertex(new Vector2f(200, 200));
        wng.lv2[0] = new Vertex(new Vector2f(100, 100));
        wng.lv2[1] = new Vertex(new Vector2f(200, 200));
        wng.lv3[0] = new Vertex(new Vector2f(100, 100));
        wng.lv3[1] = new Vertex(new Vector2f(200, 200));
        // Start the game loop
        while (window.IsOpen)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                // Move the player down
                wng.Coeffecient -= 0.01;
                wng.rotation -= 0.5;
            }

            // Check if the S key is being pressed
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                // Move the player up
                wng.Coeffecient += 0.01;
                wng.rotation += 0.5;
            }

            // Process events
            window.DispatchEvents();

            // Clear screen
            window.Clear(Color.Transparent);
            ar.Draw(window);
            // Draw the sprite (should be done with classes) (wing should be drawn first)
            wng.Draw(window);


            // Update the window
            window.Display();
        }
    }
}