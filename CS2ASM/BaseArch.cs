﻿using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CS2ASM
{
    public abstract unsafe class BaseArch
    {
        public StringWriter _Code = new StringWriter();
        public int InstructionIndex = 0;

        public int PointerSize = 8;

        public void SkipNextInstruction()
        {
            InstructionIndex++;
        }

        public virtual void Append(string s = "")
        {
            _Code.WriteLine(s);
        }

        public Dictionary<Code, MethodInfo> ILBridgeMethods = new Dictionary<Code, MethodInfo>();
        public abstract void Translate(MethodDef meth);
        public abstract void InitializeStaticFields(IList<TypeDef> types);
        public IEnumerable<Instruction> GetAllBranches(MethodDef def)
        {
            return from Br in def.Body.Instructions
                   where
(
Br.OpCode.Code == Code.Br ||
Br.OpCode.Code == Code.Brfalse ||
Br.OpCode.Code == Code.Brfalse_S ||
Br.OpCode.Code == Code.Brtrue ||
Br.OpCode.Code == Code.Brtrue_S ||
Br.OpCode.Code == Code.Br_S ||
Br.OpCode.Code == Code. Bne_Un ||
Br.OpCode.Code == Code. Bne_Un_S ||
Br.OpCode.Code == Code. Beq ||
Br.OpCode.Code == Code. Beq_S
)
                   select Br;
        }

        internal abstract void After();
        public abstract void Before(ModuleDefMD def);
    }
}
