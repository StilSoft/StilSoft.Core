using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace StilSoft.Core.Extensions
{
    public static class ByteArrayExtension
    {
        private const ushort DefaultCrcPolynomial = 0xA001;

        public static byte[] RotateLeft(this byte[] array, int numberOfBytes)
        {
            byte[] resArr = new byte[array.Length];

            if (array.Length <= 0)
            {
                return resArr;
            }

            int nByteShift = numberOfBytes / (sizeof(byte) * 8);
            int nBitShift = numberOfBytes % (sizeof(byte) * 8);

            if (nByteShift >= array.Length)
            {
                nByteShift %= array.Length;
            }

            int s = array.Length - 1;
            int d = s - nByteShift;

            for (int cnt = 0; cnt < array.Length; cnt++, d--, s--)
            {
                while (d < 0)
                {
                    d += array.Length;
                }

                while (s < 0)
                {
                    s += array.Length;
                }

                byte byteS = array[s];

                resArr[d] |= (byte)(byteS << nBitShift);
                resArr[d > 0 ? d - 1 : resArr.Length - 1] |= (byte)(byteS >> ((sizeof(byte) * 8) - nBitShift));
            }

            return resArr;
        }

        public static byte[] RotateRight(this byte[] array, int numberOfBytes)
        {
            return RotateLeft(array, (array.Length * 8) - numberOfBytes);
        }

        public static T ToStructure<T>(this byte[] bytes) where T : struct
        {
            T structure;
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);

            try
            {
                structure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }

            return structure;
        }

        public static bool Compare(this byte[] array1, byte[] array2)
        {
            return array1.SequenceEqual(array2);
        }

        public static bool Compare(byte[] array1, int array1StartIndex, byte[] array2, int array2StartIndex, int length)
        {
            if (array1StartIndex >= array1.Length || array2StartIndex >= array2.Length)
            {
                throw new ArgumentException("Start index is greater than the number of elements in array");
            }

            if (array1.Length - array1StartIndex < length || array2.Length - array2StartIndex < length)
            {
                return false;
            }

            for (int i = 0; i < length; i++)
            {
                if (array1[array1StartIndex + i] != array2[array2StartIndex + i])
                {
                    return false;
                }
            }

            return true;
        }

        public static void Replace(this byte[] sourceArray, int sourceArrayOffset, byte[] data, int dataLength)
        {
            if (sourceArray.Length < sourceArrayOffset + dataLength)
            {
                throw new ArgumentOutOfRangeException(nameof(dataLength),
                    "Data length is bigger then source array length");
            }

            if (data.Length < dataLength)
            {
                throw new ArgumentOutOfRangeException(nameof(dataLength),
                    "Actual data length is lower then requested data length");
            }

            for (int i = 0; i < dataLength; i++)
            {
                sourceArray[i + sourceArrayOffset] = data[i];
            }
        }

        public static byte[] XoR(this byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                throw new ArgumentException("Both array must have same length");
            }

            int length = array1.Length;
            byte[] result = new byte[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = (byte)(array1[i] ^ array2[i]);
            }

            return result;
        }

        public static ushort CalculateCrc16(this byte[] array, ushort polynomial = DefaultCrcPolynomial)
        {
            return Crc16Calculator.ComputeChecksum(array, polynomial);
        }
    }
}