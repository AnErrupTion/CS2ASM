﻿namespace System.Runtime.CompilerServices
{
    public enum Methods
    {
        ASM,
        Allocate,
        StringCtor,
        Dispose,
        ArrayCtor,
        Stackalloc
    }

    class CompilerMethodAttribute : Attribute
    {
        private Methods Methods;

        public CompilerMethodAttribute(Methods methods) { }
    }
}
