namespace TPRandomizer.Assets
{
    using System.Collections.Generic;

    /// <summary>
        /// summary text.
        /// </summary>
    public class Flags
    {
        /// <summary>
        /// summary text.
        /// </summary>
        public static readonly byte[,] FaronTwilightRegionFlags = new byte[,]
            {
                { 0x2, 0x46 }, // Midna jump 1 mist area.
                { 0x2, 0x47 }, // Midna jump 1 mist area.
                { 0x2, 0x5D }, // North Faron Portal.
                { 0x2, 0x98 }, // South Faron Portal.
                { 0x0, 0x6B }, // Ordon Spring Portal.
            };

        /// <summary>
        /// summary text.
        /// </summary>
        public static readonly byte[,] EldinTwilightRegionFlags = new byte[,]
            {
                { 0x3, 0x14 }, // Collected Tear From Bomb Storage
                { 0x3, 0x1A }, // Collected Tear From Bomb Storage
                { 0x3, 0x1B }, // Collected Tear From Bomb Storage
                { 0x3, 0x40 }, // Kakariko Village Portal
                { 0x3, 0x4A }, // Death Mountain Portal
                { 0x3, 0xA7 }, // Unlock Jumps to top of Sanctuary
            };

        /// <summary>
        /// summary text.
        /// </summary>
        public static readonly byte[,] BaseRandomizerRegionFlags = new byte[,]
            {
                { 0x0, 0x57 }, // Spider on Link's Ladder killed.
                { 0x16, 0x47 }, // West Bridge in CiTS Broken.
                { 0x16, 0x4D }, // West Bridge in CiTS Extended.
                { 0x16, 0x5D }, // West Bridge in CiTS Spinner Slot Closed.
                { 0x16, 0x6D }, // West Bridge in CiTS Extended.
                { 0x16, 0x6B }, // West Bridge in CiTS Destroyed CS Trigger.
                { 0x2, 0x63 }, // Trill lets you shop at his store.
                { 0x2, 0x60 }, // Got Lantern Back from Monkey
                { 0x6, 0x4C }, // Bridge of Eldin Warped back CS.
                { 0xA, 0x69 }, // Desert Entrance CS.
                { 0x3, 0xA4 }, // Barnes Sells Bombs.
                { 0x6, 0x7E }, // Kakariko Gorge placed CS
                { 0x10, 0x49 }, // FT Ook Bridge Destroyed
            };

        /// <summary>
        /// summary text.
        /// </summary>
        public static readonly byte[,] IntroRegionFlags = new byte[,]
            {
                { 0x0, 0x63 }, // Spawn the Chest in Link's House
                { 0x2, 0x4B }, // Unlock North Faron Woods Gate
            };

        /// <summary>
        /// summary text.
        /// </summary>
        public static readonly Dictionary<int, byte[,]> RegionFlags = new ()
        {
            { 0, IntroRegionFlags },
            { 1, FaronTwilightRegionFlags },
            { 2, EldinTwilightRegionFlags },
        };

        /// <summary>
        /// summary text.
        /// </summary>
        public static readonly byte[,] BaseRandomizerEventFlags = new byte[,]
        {
            { 0x6, 0x9 }, // Tame Epona, KB1 trigger activated
            { 0x14, 0x10 }, // Put Bo outside, ready to wrestle
            { 0xA, 0x2F }, // Bridge of Eldin Stolen, KB1 defeated, KB1 started
            { 0xF, 0x8 }, // Bridge of Eldin Warped Back
            { 0x40, 0x8 }, // Visited Gerudo Desert for the first time.
            { 0x7, 0xA0 }, // Watched Colin CS after KB1, talked to Bo before sumo
            { 0x20, 0x20 }, // Master Sword Story Progression
            { 0x20, 0x10 }, // Arbiters Grounds Story Progression
            { 0x2C, 0x10 }, // Raised the mirror in the Mirror Chamber
            { 0x1B, 0x38 }, // Skip Monkey Escort
            { 0x6, 0x20 }, // Warped Kakariko Bridge Back.
            { 0x5F, 0x20 }, // Shad leaves sanctuary.
        };

        /// <summary>
        /// summary text.
        /// </summary>
        public static readonly byte[,] FaronTwilightEventFlags = new byte[,]
        {
            { 0x5, 0x7F }, // Midna Charge Unlocked, Finished Sewers, Midna text after entering Faron Twilight, Met Zelda in sewers, Midna cut prison chain, Watched Sewers intro CS, Escaped cell in sewers.
            { 0x6, 0x10 }, // Cleared Faron Twilight
            { 0xC, 0x18 }, // Midna accompanies Wolf, sword and shield removed from wolf's back.
            { 0x3, 0x2 }, // Gave Wooden Sword to Talo
            { 0x43, 0x8 }, // Senses unlocked
        };

        /// <summary>
        /// summary text.
        /// </summary>
        public static readonly byte[,] EldinTwilightEventFlags = new byte[,]
        {
            { 0x7, 0x8 }, // Cleared Eldin Twilight
            { 0x6, 0x4 }, // Map Warping unlocked.
        };

        /// <summary>
        /// summary text.
        /// </summary>
        public static readonly byte[,] IntroEventFlags = new byte[,]
        {
            { 0x4, 0x4 }, // Talked to Uli Day 1.
            { 0x45, 0x10 }, // Saved Talo
            { 0x10, 0x1 }, // Cat got Fish
            { 0x3, 0x2 }, // Gave Wooden Sword to Talo
            { 0x4A, 0x40 }, // Completed Ordon Day 1.
            { 0x16, 0x1 }, // Completed Ordon Day 2.
            { 0x15, 0x80 }, // Watched CS for Goats 2 Done.
            { 0x46, 0x10 }, // Rode Epona back to Link's House
            { 0x12, 0x8 }, // Can use Sera's Shop.
        };

        /// <summary>
        /// summary text.
        /// </summary>
        public static readonly Dictionary<int, byte[,]> EventFlags = new ()
        {
            { 0, IntroEventFlags },
            { 1, FaronTwilightEventFlags },
            { 2, EldinTwilightEventFlags },
        };
        private static readonly RandomizerSetting RandomizerSettings = Randomizer.RandoSetting;
        /// <summary>
        /// summary text.
        /// </summary>
        public static readonly bool[] FlagSettings = new bool[]
        {
            RandomizerSettings.introSkipped,
            RandomizerSettings.faronTwilightCleared,
            RandomizerSettings.eldinTwilightCleared,
        };
    }
}