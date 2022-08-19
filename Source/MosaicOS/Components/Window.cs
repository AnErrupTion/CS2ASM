using System.Platform.Amd64;
using MosaicOS.Environment;

namespace MosaicOS.Components;

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

		Display.FillRectangle(X - 2, Y - 2, Width + 4, Height + 4, WindowManager.ActiveWindow == this ? Accents.ActiveTitlebarColor : Accents.InactiveTitlebarColor);
		Display.FillRectangle(X, Y, Width, Height, Accents.BodyColor);
		Display.FillRectangle(X, Y + 20, Width, 2, Accents.ActiveTitlebarColor);
		Display.DrawText(Title, X + 2, Y + 2, 0xFFFFFF);
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