using System.Collections.Generic;
using MosaicOS.Components;

namespace MosaicOS.Environment;

public static class WindowManager
{
    public static List<Window> Windows = new(5);
    public static Window ActiveWindow;
    public static bool IsWindowMoving;
}