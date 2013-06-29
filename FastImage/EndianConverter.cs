using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastImage
{
    public class EndianConverter
    {
        public static UInt16 SwapUInt16(UInt16 inValue)
        {
            byte[] byteArray = BitConverter.GetBytes(inValue);
            Array.Reverse(byteArray);
            return BitConverter.ToUInt16(byteArray, 0);
        }

        public static UInt32 SwapUInt32(UInt32 inValue)
        {
            byte[] byteArray = BitConverter.GetBytes(inValue);
            Array.Reverse(byteArray);
            return BitConverter.ToUInt32(byteArray, 0);
        }
    }
}
