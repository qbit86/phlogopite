using System;
using System.Runtime.InteropServices;

namespace Phlogopite
{
    // https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Diagnostics/Tracing/TraceLogging/PropertyValue.cs

    [StructLayout(LayoutKind.Explicit)]
    internal struct Scalar
    {
        [FieldOffset(0)]
        public bool AsBoolean;
        [FieldOffset(0)]
        public byte AsByte;
        [FieldOffset(0)]
        public sbyte AsSByte;
        [FieldOffset(0)]
        public char AsChar;
        [FieldOffset(0)]
        public short AsInt16;
        [FieldOffset(0)]
        public ushort AsUInt16;
        [FieldOffset(0)]
        public int AsInt32;
        [FieldOffset(0)]
        public uint AsUInt32;
        [FieldOffset(0)]
        public long AsInt64;
        [FieldOffset(0)]
        public ulong AsUInt64;
        [FieldOffset(0)]
        public float AsSingle;
        [FieldOffset(0)]
        public double AsDouble;
        [FieldOffset(0)]
        public DateTime AsDateTime;
    }
}
