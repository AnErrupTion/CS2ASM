﻿using static System.Runtime.Intrinsic;

namespace System.Platform.Amd64
{
    public static unsafe class Console
    {
        public const byte Width = 80;
        public const byte Height = 25;

        private static byte Color = 0;
        public static ulong CursorX = 0;
        public static ulong CursorY = 0;

        static Console()
        {
            ResetColor();
            Clear();

            EnableCursor();
            SetCursorStyle(0b1110);
        }

        private static void SetCursorStyle(byte style)
        {
            x64.Out8(0x3D4, 0x0A);
            x64.Out8(0x3D5, style);
        }

        private static void EnableCursor()
        {
            x64.Out8(0x3D4, 0x0A);
            x64.Out8(0x3D5, (byte)((x64.In8(0x3D5) & 0xC0) | 0));

            x64.Out8(0x3D4, 0x0B);
            x64.Out8(0x3D5, (byte)((x64.In8(0x3D5) & 0xE0) | 15));
        }

        public static void Write(string s)
        {
            for (byte i = 0; i < s.Length; i++)
            {
                Console.Write(s[i]);
            }
        }

        public static void Back() 
        {
            if (CursorX == 0) return;
            CursorX--;
            WriteAt(' ', CursorX, CursorY);
            UpdateCursor();
        }

        public static void WriteStrAt(string s, byte line)
        {
            for (byte i = 0; i < s.Length; i++)
            {
                Console.WriteAt(s[i], i, line);
            }
        }

        public static void ResetColor()
        {
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
        }

        public static void Write(char chr)
        {
            byte* p = ((byte*)(0xb8000 + (CursorY * Width * 2) + (CursorX * 2)));
            *p = (byte)chr;
            p++;
            *p = Color;
            CursorX++;
            if (CursorX == Width)
            {
                CursorX = 0;
                CursorY++;
            }
            if (CursorY >= Height - 1)
            {
                x64.Movsb((void*)0xb8000, (void*)0xB80A0, 0xF00);
                for (ulong i = 0; i < Width; i++) WriteAt(' ', i, CursorY);
                CursorY--;
            }
            UpdateCursor();
        }

        private static void UpdateCursor()
        {
            ulong pos = (CursorY * Width) + CursorX;
            x64.Out8(0x3D4, 0x0F);
            x64.Out8(0x3D5, (byte)(pos & 0xFF));
            x64.Out8(0x3D4, 0x0E);
            x64.Out8(0x3D5, (byte)((pos >> 8) & 0xFF));
        }

        public static char ReadKey()
        {
            char Key = '?';

            while (true) 
            {
                Key = PS2Keyboard.GetKey();
                if (Key != '?') break;
            };

            return Key;
        }

        public static void WriteLine(string s)
        {
            Write(s);
            CursorX = 0;
            CursorY++;
            UpdateCursor();
        }

        public static void WriteLine()
        {
            CursorX = 0;
            CursorY++; 
            UpdateCursor();
        }

        public static void WriteAt(char chr, ulong x, ulong y)
        {
            byte* p = (byte*)0xb8000 + ((y * Width + x) * 2);
            *p = (byte)chr;
            p++;
            *p = Color;
        }

        public static void Clear()
        {
            CursorX = 0;
            CursorY = 0;
            for(ulong x = 0; x < Width; x++) 
            {
                for(ulong y = 0; y < Height; y++) 
                {
                    WriteAt(' ', x, y);
                }
            }
        }

        public static byte ForegroundColor
        {
            get { return (byte)(Color & 0x0F); }
            set { Color &= 0xF0; Color |= (byte)(value & 0x0F); }
        }

        public static byte BackgroundColor
        {
            get { return (byte)(Color >> 4); }
            set { Color &= 0x0F; Color |= (byte)((value & 0x0F) << 4); }
        }
    }
}
