using System.Platform.Amd64;
using System.Runtime.CompilerServices;

namespace Mosaic
{
    public static unsafe class Program
    {
        public static void Main() {}

        [CompilerMethod(Methods.EntryPoint)]
        public static void Main(MultibootInfo* info, ulong _)
        {
            Display.Initialize();
            Mouse.Initialize();

            for (;;)
            {
                Display.Clear(0);
                Display.DrawText("FPS:", 10, 10, 0xFFFFFFFF);
                Display.DrawText(((ulong)FPSMeter.FPS).ToString(), 42, 10, 0xFFFFFFFF);
                Mouse.Draw();
                Display.Update();
                FPSMeter.Update();
            }
        }
    }
}