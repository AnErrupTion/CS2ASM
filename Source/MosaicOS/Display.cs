using System.Platform.Amd64;

namespace MosaicOS;

public static class Display
{
    public const int Width = 1024;
    public const int Height = 768;
    
    public static void Initialize()
    {
        BGA.Setup();
        BGA.SetVideoMode(Width, Height);
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

    public static void DrawText(string text, int x, int y, uint color)
    {
        ASC16.DrawString(text, (uint)x, (uint)y, color);
    }

    public static void FillRectangle(int x, int y, int width, int height, uint color)
    {
        for (var yy = 0; yy < height; yy++)
            for (var xx = 0; xx < width; xx++)
                DrawPoint(xx + x, yy + y, color);
    }
    
    public static bool IsInBounds(int x1, int x2, int y1, int y2, int width, int height)
    {
        return x1 >= x2 && x1 <= x2 + width && y1 >= y2 && y1 <= y2 + height;
    }
    
    public static void Update()
    {
        BGA.Update();
    }
}