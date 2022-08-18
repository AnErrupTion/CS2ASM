using System.Platform.Amd64;

namespace Mosaic;

public static class Mouse
{
    public static int X => PS2Mouse.X;
    
    public static int Y => PS2Mouse.Y;
    
    public static MouseStatus State => PS2Mouse.MouseStatus;
    
    private static int[] _cursor;
    
    public static void Initialize()
    {
        _cursor = new[]
        {
            1,0,0,0,0,0,0,0,0,0,0,0,
            1,1,0,0,0,0,0,0,0,0,0,0,
            1,2,1,0,0,0,0,0,0,0,0,0,
            1,2,2,1,0,0,0,0,0,0,0,0,
            1,2,2,2,1,0,0,0,0,0,0,0,
            1,2,2,2,2,1,0,0,0,0,0,0,
            1,2,2,2,2,2,1,0,0,0,0,0,
            1,2,2,2,2,2,2,1,0,0,0,0,
            1,2,2,2,2,2,2,2,1,0,0,0,
            1,2,2,2,2,2,2,2,2,1,0,0,
            1,2,2,2,2,2,2,2,2,2,1,0,
            1,2,2,2,2,2,2,2,2,2,2,1,
            1,2,2,2,2,2,2,1,1,1,1,1,
            1,2,2,2,1,2,2,1,0,0,0,0,
            1,2,2,1,0,1,2,2,1,0,0,0,
            1,2,1,0,0,1,2,2,1,0,0,0,
            1,1,0,0,0,0,1,2,2,1,0,0,
            0,0,0,0,0,0,1,2,2,1,0,0,
            0,0,0,0,0,0,0,1,2,2,1,0,
            0,0,0,0,0,0,0,1,2,2,1,0,
            0,0,0,0,0,0,0,0,1,1,0,0
        };
    }

    public static void Draw()
    {
        for (var h = 0; h < 21; h++)
            for (var w = 0; w < 12; w++)
            {
                if (_cursor[h * 12 + w] == 1)
                    Display.DrawPoint(w + PS2Mouse.X, h + PS2Mouse.Y, 0xFFFFFFFF);

                if (_cursor[h * 12 + w] == 2)
                    Display.DrawPoint(w + PS2Mouse.X, h + PS2Mouse.Y, 0x0);
            }
    }
    
    public static bool IsInBounds(int x, int y, int width, int height)
    {
        return Display.IsInBounds(X, x, Y, y, width, height);
    }
}