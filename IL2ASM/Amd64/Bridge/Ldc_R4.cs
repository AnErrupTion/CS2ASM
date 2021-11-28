using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldc_R4)]
        public static void Ldc_R4(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ldc_R4 is not implemented");
        }
    }
}
