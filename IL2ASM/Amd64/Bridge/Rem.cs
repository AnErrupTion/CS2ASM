using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Rem)]
        public static void Rem(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException();
        }
    }
}
