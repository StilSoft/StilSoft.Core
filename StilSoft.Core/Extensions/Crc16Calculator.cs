namespace StilSoft.Core.Extensions
{
    internal static class Crc16Calculator
    {
        private static ushort[] GenerateTable(ushort polynomial)
        {
            ushort[] crcTable = new ushort[256];

            for (ushort i = 0; i < crcTable.Length; ++i)
            {
                ushort value = 0;
                ushort temp = i;

                for (byte j = 0; j < 8; ++j)
                {
                    if (((value ^ temp) & 0x0001) != 0)
                    {
                        value = (ushort)((value >> 1) ^ polynomial);
                    }
                    else
                    {
                        value >>= 1;
                    }

                    temp >>= 1;
                }

                crcTable[i] = value;
            }

            return crcTable;
        }

        public static ushort ComputeChecksum(byte[] bytes, ushort polynomial)
        {
            ushort[] crcTable = GenerateTable(polynomial);

            ushort crc = 0;

            foreach (byte b in bytes)
            {
                byte index = (byte)(crc ^ b);

                crc = (ushort)((crc >> 8) ^ crcTable[index]);
            }

            return crc;
        }
    }
}