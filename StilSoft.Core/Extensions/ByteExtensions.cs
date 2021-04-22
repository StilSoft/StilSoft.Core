namespace StilSoft.Core.Extensions
{
    public static class ByteExtensions
    {
        public static byte RotateLeft(this byte value, int numberOfBits)
        {
            const byte mask = 0xFF;

            return (byte)(((value << numberOfBits) | (value >> (8 - numberOfBits))) & mask);
        }

        public static byte RotateRight(this byte val, int numberOfBits)
        {
            const byte mask = 0xFF;

            return (byte)(((val >> numberOfBits) | (val << (8 - numberOfBits))) & mask);
        }
    }
}