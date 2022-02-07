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
        private List<byte> GCIHeader;
        private char regionCode;
        private List<byte> GCIFile;
        private List<byte> GCIData;
        public SeedData currentSeedData = new SeedData();

        byte[] header
        {
            get { return GCIHeader.ToArray<byte>(); }
        }

        byte[] data
        {
            get { return GCIData.ToArray<byte>(); }
        }

        public byte[] gciFile
        {
            get { return GCIFile.ToArray<byte>(); }
        }
        public int length
        {
            get { return GCIHeader.Count + GCIData.Count; }
        }

        /// <summary>
        /// The class used to generate a seed data gci file.
        /// </summary>
        /// <param name="length">Number of bytes to store in the gci</param>
        /// <param name="regionCode"> E, P, or J</param>
        public Gci(byte seedNumber = 0, string seedRegion = "NTSC", List<byte> seedData = null)
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

            GCIHeader = new List<byte>();
            GCIData = new List<byte>();
            GCIFile = new List<byte>();
            // Populate GCI Header
            /*x0*/
            GCIHeader.AddRange(Converter.StringBytes("GZ2"));
            /*x3*/
            GCIHeader.Add(Converter.StringBytes(regionCode));
            /*x4*/
            GCIHeader.AddRange(Converter.StringBytes("01"));
            /*x6*/
            GCIHeader.Add(Converter.gcByte(0xFF));
            /*x7*/
            GCIHeader.Add(Converter.gcByte(1));
            /*x8*/
            GCIHeader.AddRange(Converter.StringBytes($"rando-data{seedNumber}", 0x20));
            /*x28*/
            GCIHeader.AddRange(
                Converter.gcBytes((UInt32)(DateTime.UtcNow - new DateTime(2000, 1, 1)).TotalSeconds)
            );
            /*x2c*/
            GCIHeader.AddRange(Converter.gcBytes((UInt32)0x8000));
            /*x30*/
            GCIHeader.AddRange(Converter.gcBytes((UInt16)0x0001)); // iconFormats
            /*x32*/
            GCIHeader.AddRange(Converter.gcBytes((UInt16)0x0002)); // iconAnimationSpeeds
            /*x34*/
            GCIHeader.Add(Converter.gcByte(0x04));
            /*x35*/
            GCIHeader.Add(Converter.gcByte(0x00));
            /*x36*/
            GCIHeader.AddRange(Converter.gcBytes((UInt16)0x00));
            /*x38*/
            GCIHeader.AddRange(Converter.gcBytes((UInt16)0x05)); // Actual num of blocks.
            /*x3A*/
            GCIHeader.AddRange(Converter.gcBytes((UInt16)0xFFFF));
            /*x3C*/
            GCIHeader.AddRange(Converter.gcBytes((UInt32)0x9400));


            GCIFile.AddRange(GCIHeader);
            GCIFile.AddRange(seedData);

            //Pad
            while (GCIFile.Count < (4 * 0x2000) + 0x40) // Pad to 4 blocks.
                GCIFile.Add((byte)0x0);

            // Add seed banner
            GCIFile.AddRange(Properties.Resources.seedGciImageData);
            GCIFile.AddRange(Converter.StringBytes("TPR 1.0 Seed Data", 0x20, regionCode));
            GCIFile.AddRange(Converter.StringBytes(Randomizer.seedHash, 0x20, regionCode));

            // Pad
            while (GCIFile.Count < (5 * 0x2000) + 0x40) // Pad to 5 blocks.
                GCIFile.Add((byte)0x0);
        }
    }
}
