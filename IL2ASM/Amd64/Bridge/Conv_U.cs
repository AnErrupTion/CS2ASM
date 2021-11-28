using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Conv_U)]
        public static void Conv_U(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Conv_U is not implemented");
        }
    }
}
