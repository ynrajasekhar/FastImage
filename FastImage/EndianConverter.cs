using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastImage
{
    public class EndianConverter
    {
        //
        public static UInt16 SwapUInt16(UInt16 inValue)
        {
            byte[] byteArray = BitConverter.GetBytes(inValue);
            Array.Reverse(byteArray);
            return BitConverter.ToUInt16(byteArray, 0);
        }

        //
        public static UInt32 SwapUInt32(UInt32 inValue)
        {
            byte[] byteArray = BitConverter.GetBytes(inValue);
            Array.Reverse(byteArray);
            return BitConverter.ToUInt32(byteArray, 0);
        }

        //// reverse byte order (16-bit)
        //public static UInt16 ReverseBytes(UInt16 value)
        //{
        //    return (UInt16) ((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        //}

        //// reverse byte order (32-bit)
        //public static UInt32 ReverseBytes(UInt32 value)
        //{
        //    return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
        //           (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        //}

        //// reverse byte order (64-bit)
        //public static UInt64 ReverseBytes(UInt64 value)
        //{
        //    return (value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
        //           (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
        //           (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
        //           (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56;
        //}

    }
}
