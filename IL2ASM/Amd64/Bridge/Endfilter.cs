using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Endfilter)]
        public static void Endfilter(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException();
        }
    }
}
