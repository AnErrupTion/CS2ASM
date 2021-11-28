using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Arglist)]
        public static void Arglist(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Arglist is not implemented");
        }
    }
}
