using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ldind_I4)]
        public static void Ldind_I4(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException();
        }
    }
}
