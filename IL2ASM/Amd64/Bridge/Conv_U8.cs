using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Conv_U8)]
        public static void Conv_U8(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException();
        }
    }
}
