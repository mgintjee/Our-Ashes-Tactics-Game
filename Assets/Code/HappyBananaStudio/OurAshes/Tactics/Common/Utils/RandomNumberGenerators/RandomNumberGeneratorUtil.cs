/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Common.Utils.RandomNumberGenerators
{
    /// <summary>
    /// Todo
    /// </summary>
    public class RandomNumberGeneratorUtil
    {
        // Todo
        private static readonly int DEFAULT_SEED = 22;

        // Todo
        private static Random random = null;

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
        /// <returns>
        /// </returns>
        public static int GetNextInt()
        {
            // Return the next value from the Random
            return random.Next();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="upperBound">
        /// </param>
        /// <returns>
        /// </returns>
        public static int GetNextInt(int upperBound)
        {
            if (upperBound != 0)
            {
                return random.Next(upperBound);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> Upper Bound=?. Cannot be 0.",
                    new StackFrame().GetMethod().Name, upperBound);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="lowerBound">
        /// </param>
        /// <param name="upperBound">
        /// </param>
        /// <returns>
        /// </returns>
        public static int GetNextInt(int lowerBound, int upperBound)
        {
            if (lowerBound < upperBound)
            {
                return random.Next(lowerBound, upperBound);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> Lower Bound=?, Upper Bound=?",
                    new StackFrame().GetMethod().Name, lowerBound, upperBound);
            }
        }
    }
}
