using MosaicOS.Environment;

namespace MosaicOS.Components;

public class Button
{
    public readonly int X, Y, Width, Height;
    public readonly string Text;

    private bool _hovering;

    public Button(string text, int x, int y, int width, int height)
    {
        Text = text;

        X = x;
        Y = y;

        Width = width;
        Height = height;
    }

    public void Draw()
    {
        Display.FillRectangle(X - 2, Y - 2, Width + 4, Height + 4, Accents.ActiveTitlebarColor);
        Display.FillRectangle(X, Y, Width, Height, _hovering ? Accents.HoverColor : Accents.BodyColor);
        Display.DrawText(Text, X, Y, Accents.ForeColor);
    }

    public void Update()
    {
        _hovering = !WindowManager.IsWindowMoving && Mouse.IsInBounds(X, Y, Width, Height);
    }
}