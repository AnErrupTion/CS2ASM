namespace ConsoleApp1.Components;

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
        Display.FillRectangle(X, Y, Width, Height, _hovering ? Accents.HoverColor : Accents.BackColor);
        Display.DrawText(Text, X, Y, Accents.ForeColor);
    }

    public void Update()
    {
        _hovering = Mouse.IsInBounds(X, Y, Width, Height);
    }
}