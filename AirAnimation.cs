using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace LiftSimulation;

internal class AirAnimation
{
    Wing wng = new Wing();
    Random rnd = new Random();
    List<RectangleShape> squares = new List<RectangleShape>();
    public int Airspeed { get; set; }

    public void Initilizer()
    {
        for (int i = 0; i < 3600; i++)
        {
            RectangleShape square = new RectangleShape(new Vector2f(2, 2));
            square.FillColor = Color.Cyan;
            square.Position = new Vector2f((float)(rnd.Next(-25,1200)), i / 5);
            squares.Add(square);
        }
    }
    public void Draw(RenderWindow wind)
    {


        // Update the position of each square
        for (int i = 0; i < squares.Count; i++)
        {
            // Move the square to the right
            
            squares[i].Position = new Vector2f(squares[i].Position.X + rnd.Next(Airspeed/2,Airspeed), squares[i].Position.Y);
    

            // If the square has moved off the right side of the screen, reset its position to the left
            if (squares[i].Position.X > wind.Size.X)
            {
                squares[i].Position = new Vector2f(rnd.Next(-100,0), squares[i].Position.Y);
            }
        }
        foreach (var square in squares)
        {
            wind.Draw(square);
        }


    }

}
