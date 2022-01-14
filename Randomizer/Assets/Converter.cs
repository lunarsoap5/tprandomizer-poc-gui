using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPRandomizer.Assets
{
    class Converter
    {
        public static byte gcByte(int x)
        {
            return (byte) x;
        }

        /// <summary>
        /// Returns x as BigEndian (GC)
        /// </summary>
        /// <param name="x">The number you want to convert.</param>

        public static byte[] gcBytes(UInt64 x)
        {
            var bytes = BitConverter.GetBytes(x);
            Array.Reverse(bytes);

            return bytes;
        }
        public static byte[] gcBytes(UInt32 x)
        {
            var bytes = BitConverter.GetBytes(x);
            Array.Reverse(bytes);

            return bytes;
        }

        public static byte[] gcBytes(UInt16 x)
        {
            var bytes = BitConverter.GetBytes(x);
            Array.Reverse(bytes);

            return bytes;
        }

         public static byte[] gcBytes(Int32 x)
        {
            var bytes = BitConverter.GetBytes(x);
            Array.Reverse(bytes);

            return bytes;
        }

        public static byte[] gcBytes(Int16 x)
        {
            var bytes = BitConverter.GetBytes(x);
            Array.Reverse(bytes);

            return bytes;
        }

        /// <summary>
        /// Get bytes from text (without null terminator)
        /// </summary>
        /// <param name="text"> The ASCII text you want to convert.</param>
        /// <returns></returns>
        public static byte[] stringBytes(String text, int desiredLength = 0, char region = 'E')
        {
            List<byte> textData = new List<byte>();

            if (region == 'J')
            {   
                textData.AddRange(Encoding.GetEncoding("shift_jis").GetBytes(text));
            }
            else
            {
                textData.AddRange(Encoding.ASCII.GetBytes(text));
            }

            //Account for padding
            while (textData.Count < desiredLength)
            {
                textData.Add(0);
            }

            return textData.ToArray<byte>();
        }

        public static byte stringBytes(char text)
        {
            return (byte)text;
        }
    }
}