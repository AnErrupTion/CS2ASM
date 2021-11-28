using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Prefixref)]
        public static void Prefixref(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Prefixref is not implemented");
        }
    }
}
