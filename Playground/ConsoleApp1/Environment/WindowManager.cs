using System.Collections.Generic;
using ConsoleApp1.Components;

namespace ConsoleApp1.Environment;

public static class WindowManager
{
    public static List<Window> Windows = new(5);
    public static Window ActiveWindow;
    public static bool IsWindowMoving;
}