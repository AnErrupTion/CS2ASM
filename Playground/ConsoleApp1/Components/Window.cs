using System.Platform.Amd64;
using ConsoleApp1.Environment;

namespace ConsoleApp1.Components;

public class Window
{
    public string Title;
   
	public int OffsetX, OffsetY, X, Y, Width, Height, TitlebarHeight = 20;
   
	public bool Held, Opened = false;
   
	public Window(string title, int x, int y, int width, int height)
	{
		Title = title;
   
		X = x;
		Y = y;
   
		Width = width;
		Height = height;
	}
   
	public virtual void Draw()
	{
		if (!Opened)
			return;
   
		// Title bar
		Display.FillRectangle(X, Y, Width, TitlebarHeight, WindowManager.ActiveWindow == this ? Accents.ActiveTitlebarColor : Accents.InactiveTitlebarColor);
   
		// Title text
		Display.DrawText(Title, X, Y, Accents.BodyColor);
   
		// Body
		Display.FillRectangle(X, Y + TitlebarHeight - 1, Width, Height, Accents.BodyColor);
	}
   
	public virtual void Update()
	{
		if (!Opened)
			return;
   
		if (WindowManager.IsWindowMoving && WindowManager.ActiveWindow != this)
			return;
   
		if (!Held && Mouse.State == (int)MouseStatus.Left && IsInBounds())
		{
			// Prevent inactive window from getting active if active window is overlapping that window
			if (WindowManager.ActiveWindow != this && IsTitlebarColliding())
				return;
   
			Held = true;
			WindowManager.IsWindowMoving = true;
   
			OffsetX = Mouse.X - X;
			OffsetY = Mouse.Y - Y;
   
			WindowManager.ActiveWindow = this;
		}
   
		if (!Held)
			return;
   
		X = Mouse.X - OffsetX;
		Y = Mouse.Y - OffsetY;
   
		Held = Mouse.State == MouseStatus.Left;
		WindowManager.IsWindowMoving = Held;
	}
   
	public bool IsTitlebarColliding()
	{
		return WindowManager.ActiveWindow.X < X + Width &&
		       WindowManager.ActiveWindow.X + WindowManager.ActiveWindow.Width > X &&
		       WindowManager.ActiveWindow.Y < Y + TitlebarHeight &&
		       WindowManager.ActiveWindow.TitlebarHeight + WindowManager.ActiveWindow.Y > Y;
	}
   
	public bool IsInBounds()
	{
		return Mouse.IsInBounds(X, Y, Width, TitlebarHeight);
	}
}