﻿/*
 * Reference: 
 * https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/x64-architecture
 * https://docs.microsoft.com/zh-cn/dotnet/api/system.reflection.emit.opcodes?view=net-6.0
*/

using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IL2ASM
{
    public unsafe class Amd64 : Arch
    {
        public override void Setup()
        {
            var methodInfos = from M in typeof(Amd64Bridge).GetMethods()
                              where M.GetCustomAttribute(typeof(ILBridgeAttribute), true) != null
                              select M;
            foreach (var v in methodInfos)
            {
                ILBridgeMethods.Add(v.GetCustomAttributes(true).OfType<ILBridgeAttribute>().First().code, v);
            }

            Append($"[bits 64]");
        }

        public override void Compile(MethodDef def, bool isEntryPoint = false)
        {

            //Get All Branches
            List<Instruction> BrS = new List<Instruction>();
            foreach (var ins in def.Body.Instructions)
            {
                if (
                    ins.OpCode == OpCodes.Br ||
                    ins.OpCode == OpCodes.Brfalse ||
                    ins.OpCode == OpCodes.Brfalse_S ||
                    ins.OpCode == OpCodes.Brtrue ||
                    ins.OpCode == OpCodes.Brtrue_S ||
                    ins.OpCode == OpCodes.Br_S
                    )
                {
                    BrS.Add(ins);
                }
            }

            //Label
            Append($"{def.SafeName()}:");

            //for call
            if (!isEntryPoint)
            {
                Append($"pop rax");
                Append($"mov [rbp+8],rax");
            }

            //For Variables
            if (def.Body.Variables.Count != 0)
                Append($"xor rax,rax");

            for (ulong i = 0; i < (ulong)def.Body.Variables.Count; i++)
            {
                Append($"push rax");
            }

            //Start Parse IL Code
            for (int i = 0; i < def.Body.Instructions.Count; i++)
            {
                var ins = def.Body.Instructions[i];

                Append($";{ins}");

                //For Branches
                foreach (var v in BrS)
                {
                    if (((Instruction)v.Operand).Offset == ins.Offset)
                        Append($"{Amd64.BrLabelName(ins, def)}:");
                }

                //Starts Here
                //Bridge
                if (ILBridgeMethods.ContainsKey(ins.OpCode.Code))
                {
                    ILBridgeMethods[ins.OpCode.Code].Invoke(null, new object[] { this, ins, def });
                }

                Append();
            }
        }

        public static string BrLabelName(Instruction ins, MethodDef def)
        {
            return $"{def.SafeName()}_IL_{((Instruction)(ins.Operand)).Offset:X4}";
        }
    }
}
