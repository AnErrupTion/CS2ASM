using System.Platform.Amd64;
using System.Runtime.CompilerServices;
using MosaicOS.Components;
using MosaicOS.Environment;

namespace MosaicOS
{
    public static unsafe class Program
    {
        public static void Main() {}

        [CompilerMethod(Methods.EntryPoint)]
        public static void Main(MultibootInfo* info, ulong _)
        {
            Display.Initialize();
            Mouse.Initialize();

            var Window1 = new Window("Window1", 50, 50, 250, 190);
            Window1.Opened = true;

            WindowManager.ActiveWindow = Window1;
            WindowManager.Windows.Add(Window1);

            var Window2 = new Window("Window2", 450, 450, 420, 325);
            Window2.Opened = true;

            WindowManager.ActiveWindow = Window2;
            WindowManager.Windows.Add(Window2);

            for (;;)
            {
                Display.Clear(0);
                Display.DrawText("FPS:", 10, 10, 0xFFFFFFFF);
                Display.DrawText(((ulong)FPSMeter.FPS).ToString(), 42, 10, 0xFFFFFFFF);
                Window1.Draw();
                Window1.Update();
                Window2.Draw();
                Window2.Update();
                Mouse.Draw();
                Display.Update();
                FPSMeter.Update();
            }
        }
    }
}
