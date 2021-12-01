using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Endfinally)]
        public static void Endfinally(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Endfinally is not implemented");
        }
    }
}
