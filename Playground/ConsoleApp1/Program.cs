﻿using System.Runtime;
using Toolkit;
using static System.Runtime.Intrinsic;

namespace ConsoleApp1
{
    public static unsafe class Program
    {
        /*
         * Current Progress:
         *  Currently, only static methods are supported.
         *  Currently, only local and static variables are supported.
         *  Pointers are supported.
         *  Void, Boolean, Char, SByte, Byte, Short, UShort, Int, UInt, Long and ULong are all supported.
         *  Arithmetic operations such as +, -, *, /, << and >> are all supported.
         *  Logic operations such as >, >=, <, <= and == are all supported.
         *  Other instructions such as loops, if statements and returning variables are all supported.
         *
         *  TODO - Free the unused strings
         *  TODO - Inherited class implementation
         */
        public static void Main()
        {
            //shutdown qemu
            //IOPort.Out16(0x604, 0x2000);

            //In8(0x60);

            Allocator.start = 0x6400000;

            Console.Setup();

            Console.Clear();
            Console.Alphabet();

            string s0 = "hello world from CS2ASM. you are already in x64 mode!";

            Console.WriteStr(s0, 1);

            string s1 = "contributor: nifanfa(Owner), LeonTheDev";

            Console.WriteStr(s1, 2);

            //Warning: Those string won't get disposed

            string pres = "ESC Pressed ";
            string rele = "ESC Released";
            for(; ; ) 
            {
                byte v = IOPort.In8(0x60);
                if (v == 0x01) //ESC
                {
                    Console.WriteStr(pres, 3);
                }
                else
                {
                    Console.WriteStr(rele, 3);
                }
            }
            //Counter();
        }

        // Counts to 9 and resets
        public static void Counter()
        {
            byte b = 0x30; // 0
        Loop:
            for (int i = 0; i < 10; i++)
            {
                Console.WriteAt((char)b, 0, 24);
                b++;
            }
            b = 0x30; // 0
            goto Loop;
        }
    }
}
