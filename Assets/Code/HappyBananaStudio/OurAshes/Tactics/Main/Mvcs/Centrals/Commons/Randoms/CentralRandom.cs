using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Commons.Randoms
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CentralRandom
    {
        // Todo
        private static readonly int DefaultSeed = 22;

        // Todo
        private static Random _random = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static Random GetInstance()
        {
            if (_random == null)
            {
                _random = new Random(DefaultSeed);
            }
            return _random;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static Random GetInstance(int seed)
        {
            if (_random == null)
            {
                // Build the Random object with the seed
                _random = new Random(seed);
            }
            return _random;
        }
    }
}