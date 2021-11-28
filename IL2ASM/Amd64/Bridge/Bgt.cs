using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Bgt)]
        public static void Bgt(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Bgt is not implemented");
        }
    }
}
