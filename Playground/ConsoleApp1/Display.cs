using System.Platform.Amd64;

namespace ConsoleApp1;

public static class Display
{
    public static void Initialize()
    {
        BGA.Setup();
        BGA.SetVideoMode(640, 480);
        PS2Mouse.X = BGA.Width / 2;
        PS2Mouse.Y = BGA.Height / 2;
    }

    public static void Clear(uint color)
    {
        BGA.Clear(color);
    }

    public static void DrawPoint(int x, int y, uint color)
    {
        BGA.DrawPoint(x, y, color);
    }

    public static void DrawText(string text, uint x, uint y, uint color)
    {
        ASC16.DrawString(text, x, y, color);
    }
    
    public static void Update()
    {
        BGA.Update();
    }
}