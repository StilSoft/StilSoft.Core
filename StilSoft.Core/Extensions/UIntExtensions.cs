﻿namespace StilSoft.Extensions
{
    public static class UIntExtensions
    {
        public static uint ReverseBytes(this uint value)
        {
            return ((value & 0x000000FFU) << 24) | ((value & 0x0000FF00U) << 8) |
                   ((value & 0x00FF0000U) >> 8) | ((value & 0xFF000000U) >> 24);
        }
    }
}