namespace TPRandomizer.Assets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Converter
    {
        public static byte gcByte(int x)
        {
            return (byte)x;
        }

        /// <summary>
        /// Returns x as BigEndian (GC).
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
        /// Get bytes from text (without null terminator).
        /// </summary>
        /// <param name="text"> The ASCII text you want to convert.</param>
        /// <param name="desiredLength"> The length of the string in bytes.</param>
        /// <param name="region"> The language region of the text you want to convert.</param>
        /// <returns>Array of Bytes processed.</returns>
        public static byte[] StringBytes(string text, int desiredLength = 0, char region = 'E')
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

            // Account for padding
            while (textData.Count < desiredLength)
            {
                textData.Add(0);
            }

            return textData.ToArray<byte>();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static byte StringBytes(char text)
        {
            return (byte)text;
        }
    }
}
