using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Box)]
        public static void Box(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Box is not implemented");
        }
    }
}
