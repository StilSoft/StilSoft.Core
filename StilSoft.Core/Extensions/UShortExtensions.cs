namespace StilSoft.Core.Extensions
{
    public static class UShortExtensions
    {
        public static ushort ReverseBytes(this ushort value)
        {
            return (ushort)(((value & 0xFFU) << 8) | ((value & 0xFF00U) >> 8));
        }
    }
}