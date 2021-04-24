using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace StilSoft.Extensions
{
    public static class StringExtensions
    {
        public static bool IsHexString(this string value)
        {
            const string hx = "0123456789ABCDEF";

            return value.ToUpper().All(c => hx.Contains(c));
        }

        public static byte[] HexStringToByteArray(this string hexString)
        {
            if (hexString.Length == 0)
            {
                return new byte[0];
            }
            
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException($"The hex string cannot have an odd number of digits: {hexString}");
            }

            string hexStringTemp = Regex.Replace(hexString, @"[^\u0030-\u0039\u0041-\u005A\u0061-\u007A]", "?");

            if (!hexStringTemp.Contains("?"))
            {
                throw new ArgumentException("The string is not in hex format");
            }

            byte[] data = new byte[hexString.Length / 2];

            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);

                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }
    }
}