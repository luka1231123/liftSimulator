using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace LiftSimulation;

internal class Wing
{
    public double AirDensity { get; set; } = 1.22; // kg/m^3
    public double AirSpeed { get; set; } = 10; // m/s
    public double Coeffecient { get; set; } = 1.3;
    public double WingArea { get; set; } = 23;
    public double Mass { get; set; } = 2;

    public double Posy { get; set; } = 0;
    public double Posx { get; set; } = 0;

    RectangleShape sqr = new RectangleShape();

    public double rotation { get; set; } = 0;

    Texture txt = new Texture("Untitled.png");

    public Vertex[] lv = new Vertex[2];
    public Vertex[] lv2 = new Vertex[2];
    public Vertex[] lv3 = new Vertex[2];
    Font font = new Font("arial.ttf");
    public void Draw(RenderWindow wind)
    {
        lv[0].Position = new SFML.System.Vector2f(0, 300);
        lv[1].Position = new SFML.System.Vector2f(625, (float)Posy+25);
 
        double Gravity = Mass * 9.8;
        double LiftForce = Coeffecient * AirDensity * ((AirSpeed * AirSpeed) / 2) * WingArea;
        double ForceY = Gravity - LiftForce;
        Posy += ForceY;
        Posx = 600;
        Sprite sprite = new Sprite(txt);
        sprite.Scale = new SFML.System.Vector2f((float)0.1, (float)0.1);
        sprite.Position = new SFML.System.Vector2f((float)Posx, (float)Posy);
        sprite.Rotation = (float)rotation;

        lv2[0].Position = new SFML.System.Vector2f(700, (float)Posy+17);
        lv2[1].Position = new SFML.System.Vector2f(700, (float)Posy - ((float)(LiftForce * 5))+20);
        lv2[0].Color = Color.Red;
        lv2[1].Color = Color.Red;
        lv3[0].Position = new SFML.System.Vector2f(700, (float)Posy+20);
        lv3[1].Position = new SFML.System.Vector2f(700, (float)Posy + ((float)(Gravity*5))+20);
        lv3[0].Color = Color.Blue;
        lv3[1].Color = Color.Blue;
        Text text = new Text($"Lift Force : {LiftForce}", font);
        text.Position = new SFML.System.Vector2f(650, (float)(Posy - 50));
        text.CharacterSize = 20;
        Text text2 = new Text($"Gravity : {Gravity}", font);
        text2.Position = new SFML.System.Vector2f(650, (float)(Posy + 75));
        text2.CharacterSize = 20;


        wind.Draw(lv, PrimitiveType.Lines);
        wind.Draw(lv2, PrimitiveType.Lines);
        wind.Draw(lv3, PrimitiveType.Lines);
        wind.Draw(text);wind.Draw(text2);

        //wind.Draw(sqr);
        wind.Draw(sprite);
    }
}
