/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Util.RandomNumberGenerator
{
    /// <summary>
    /// Todo
    /// </summary>
    public class RandomNumberGeneratorUtil
    {
        #region Private Fields

        // Todo
        private static readonly int DEFAULT_SEED = 22;

        // Todo
        private static Random random = null;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        public static void BuildRandom(int seed)
        {
            // Check that the Random is non-null
            if (random == null)
            {
                // Build the Random object with the seed
                random = new Random(seed);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static void BuildRandom()
        {
            BuildRandom(DEFAULT_SEED);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static int GetNextInt()
        {
            // Return the next value from the Random
            return random.Next();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="upperBound"></param>
        /// <returns></returns>
        public static int GetNextInt(int upperBound)
        {
            if (upperBound != 0)
            {
                return random.Next(upperBound);
            }
            else
            {
                throw new ArgumentException("Invalid Parameters. UpperBound=" + upperBound + " must be not equal 0");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="lowerBound"></param>
        /// <param name="upperBound"></param>
        /// <returns></returns>
        public static int GetNextInt(int lowerBound, int upperBound)
        {
            if (lowerBound < upperBound)
            {
                return random.Next(lowerBound, upperBound);
            }
            else
            {
                throw new ArgumentException("Invalid Parameters. LowerBound=" + lowerBound + " must be less than UpperBound=" + upperBound);
            }
        }

        #endregion Public Methods
    }
}