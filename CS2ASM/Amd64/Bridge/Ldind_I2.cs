using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldind_I2)]
        public static void Ldind_I2(Arch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rax");
            arch.Append($"push qword [rax]");
        }
    }
}
