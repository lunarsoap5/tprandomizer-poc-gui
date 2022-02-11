namespace TPRandomizer.Assets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// summary text.
    /// </summary>
    public class Gci
    {
        private readonly List<byte> gciHeader;
        private readonly char regionCode;
        public List<byte> gciFile;
        private readonly List<byte> gciData;

        private byte[] Header
        {
            get { return gciHeader.ToArray<byte>(); }
        }

        private byte[] Data
        {
            get { return gciData.ToArray<byte>(); }
        }

        private byte[] GCIFile
        {
            get { return gciFile.ToArray<byte>(); }
        }

        private int Length
        {
            get { return gciHeader.Count + gciData.Count; }
        }

        /// <summary>
        /// text.
        /// </summary>
        /// <param name="seedNumber">The current seed number that the memory card will read.</param>
        /// <param name="seedRegion">The region of the game that the seed is being generated for.</param>
        /// <param name="seedData">Any data that needs to be read into the GCI file.</param>
        /// <returns> The inserted value as a byte. </returns>
        public Gci(byte seedNumber = 0, string seedRegion = "NTSC", List<byte> seedData = null, string seedHash = "")
        {
            char regionCode;
            switch (seedRegion)
            {
                case "JAP":
                    regionCode = 'J';
                    break;
                case "PAL":
                    regionCode = 'P';
                    break;
                default:
                    regionCode = 'E';
                    break;
            }

            gciHeader = new List<byte>();
            gciData = new List<byte>();
            gciFile = new List<byte>();

            // Populate GCI Header
            /*x0*/
            gciHeader.AddRange(Converter.StringBytes("GZ2"));
            /*x3*/
            gciHeader.Add(Converter.StringBytes(regionCode));
            /*x4*/
            gciHeader.AddRange(Converter.StringBytes("01"));
            /*x6*/
            gciHeader.Add(Converter.GcByte(0xFF));
            /*x7*/
            gciHeader.Add(Converter.GcByte(1));
            /*x8*/
            gciHeader.AddRange(Converter.StringBytes($"rando-data{seedNumber}", 0x20));
            /*x28*/
            gciHeader.AddRange(Converter.GcBytes((UInt32)(DateTime.UtcNow - new DateTime(2000, 1, 1)).TotalSeconds));
            /*x2c*/
            gciHeader.AddRange(Converter.GcBytes((UInt32)0x8000));
            /*x30*/
            gciHeader.AddRange(Converter.GcBytes((UInt16)0x0001)); // iconFormats
            /*x32*/
            gciHeader.AddRange(Converter.GcBytes((UInt16)0x0002)); // iconAnimationSpeeds
            /*x34*/
            gciHeader.Add(Converter.GcByte(0x04));
            /*x35*/
            gciHeader.Add(Converter.GcByte(0x00));
            /*x36*/
            gciHeader.AddRange(Converter.GcBytes((UInt16)0x00));
            /*x38*/
            gciHeader.AddRange(Converter.GcBytes((UInt16)0x05)); // Actual num of blocks.
            /*x3A*/
            gciHeader.AddRange(Converter.GcBytes((UInt16)0xFFFF));
            /*x3C*/
            gciHeader.AddRange(Converter.GcBytes((UInt32)0x9400));

            gciFile.AddRange(gciHeader);
            gciFile.AddRange(seedData);

            // Pad
            while (gciFile.Count < (4 * 0x2000) + 0x40) // Pad to 4 blocks.
                gciFile.Add((byte)0x0);

            // Add seed banner
            gciFile.AddRange(Properties.Resources.seedGciImageData);
            gciFile.AddRange(Converter.StringBytes("TPR 1.0 Seed Data", 0x20, regionCode));
            gciFile.AddRange(Converter.StringBytes(seedHash, 0x20, regionCode));

            // Pad
            while (gciFile.Count < (5 * 0x2000) + 0x40) // Pad to 5 blocks.
                gciFile.Add((byte)0x0);
        }
    }
}
