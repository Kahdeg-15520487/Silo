using System;
using System.Collections;
// ReSharper disable InconsistentNaming

namespace Silo.Util
{
    /// <summary>
    /// Extension methods for Silo
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Represent this int in Hertz
        /// </summary>
        /// <param name="a">int value</param>
        /// <returns>This int as a Hz Frequency</returns>
        public static Frequency Hz(this int a)
        {
            return Frequency.Parse($"{a} Hz");
        }

        /// <summary>
        /// Represent this double in Hertz
        /// </summary>
        /// <param name="a">double value</param>
        /// <returns>This double as a Hz Frequency</returns>
        public static Frequency Hz(this double a)
        {
            return Frequency.Parse($"{a} Hz");
        }

        /// <summary>
        /// Represent this int in Kilohertz
        /// </summary>
        /// <param name="a">int value</param>
        /// <returns>This int as a kHz Frequency</returns>
        public static Frequency kHz(this int a)
        {
            return Frequency.Parse($"{a} kHz");
        }

        /// <summary>
        /// Represent this double in Kilohertz
        /// </summary>
        /// <param name="a">double value</param>
        /// <returns>This double as a kHz Frequency</returns>
        public static Frequency kHz(this double a)
        {
            return Frequency.Parse($"{a} kHz");
        }

        /// <summary>
        /// Convert this byte to a little endian bool array
        /// </summary>
        /// <param name="b">Byte value</param>
        /// <returns>Little endian bool array</returns>
        public static bool[] ConvertToBoolArray(this int b, int count = 32)
        {
            // prepare the return result
            var result = new bool[count];

            // check each bit in the byte. if 1 set to true, if 0 set to false
            for (var i = 0; i < count; i++)
                result[i] = (b & (1 << i)) != 0;

            // reverse the array
            Array.Reverse(result);

            return result;
        }

        /// <summary>
        /// Convert this byte to a little endian bool array
        /// </summary>
        /// <param name="b">Byte value</param>
        /// <returns>Little endian bool array</returns>
        public static bool[] ConvertToBoolArray(this uint b, int count = 32)
        {
            // prepare the return result
            var result = new bool[count];

            // check each bit in the byte. if 1 set to true, if 0 set to false
            for (var i = 0; i < count; i++)
                result[i] = (b & (1 << i)) != 0;

            // reverse the array
            Array.Reverse(result);

            return result;
        }

        /// <summary>
        /// Convert this byte to a little endian bool array
        /// </summary>
        /// <param name="b">Byte value</param>
        /// <returns>Little endian bool array</returns>
        public static bool[] ConvertToBoolArray(this byte b, int count = 8)
        {
            // prepare the return result
            var result = new bool[count];

            // check each bit in the byte. if 1 set to true, if 0 set to false
            for (var i = 0; i < count; i++)
                result[i] = (b & (1 << i)) != 0;

            // reverse the array
            Array.Reverse(result);

            return result;
        }

        /// <summary>
        /// Convert this little endian bool array to a byte
        /// </summary>
        /// <param name="source">Little endian bool array</param>
        /// <returns>Byte value</returns>
        public static byte ConvertToByte(this bool[] source)
        {
            byte result = 0;
            // This assumes the array never contains more than 8 elements!
            var index = 8 - source.Length;

            // Loop through the array
            foreach (var b in source)
            {
                // if the element is 'true' set the bit at that position
                if (b)
                    result |= (byte)(1 << (7 - index));

                index++;
            }

            return result;
        }

        /// <summary>
        /// Convert this little endian bool array to a byte
        /// </summary>
        /// <param name="source">Little endian bool array</param>
        /// <returns>Byte value</returns>
        public static uint ConvertToUInt(this bool[] source)
        {
            if (source.Length > 32) throw new ArgumentException("Can only fit 32 bits in a uint");

            uint[] r = new uint[1];
            BitArray arr = new BitArray(source.Reverse().ToArray());
            arr.CopyTo(r, 0);
            return r[0];
        }
    }
}