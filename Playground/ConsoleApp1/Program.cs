using System.Platform.Amd64;
using System.Runtime.CompilerServices;
using ConsoleApp1.Components;
using ConsoleApp1.Environment;

namespace ConsoleApp1
{
    public static unsafe class Program
    {
        public static void Main() {}

        [CompilerMethod(Methods.EntryPoint)]
        public static void Main(MultibootInfo* info, ulong _)
        {
            Display.Initialize();
            Mouse.Initialize();

            var test = new Window("Test Window", 50, 50, 250, 190);
            test.Opened = true;

            WindowManager.ActiveWindow = test;
            WindowManager.Windows.Add(test);

            var button = new Button("Test Button", 80, 120, 90, 20);

            for (;;)
            {
                Display.Clear(0);
                Display.DrawText("FPS:", 10, 10, 0xFFFFFFFF);
                Display.DrawText(((ulong)FPSMeter.FPS).ToString(), 42, 10, 0xFFFFFFFF);
                test.Draw();
                test.Update();
                button.Draw();
                button.Update();
                Mouse.Draw();
                Display.Update();
                FPSMeter.Update();
            }
        }
    }
}
