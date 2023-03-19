using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Randoms
{
    /// <summary>
    /// Random Manager for all Mvc Types
    /// </summary>
    public static class RandomManager
    {
        // Todo
        private static readonly IDictionary<MvcType, Random> MvcTypeRandoms = new Dictionary<MvcType, Random>();

        // Todo
        private static readonly int DefaultSeed = 20150123;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcType"></param>
        /// <returns></returns>
        public static Random GetRandom(MvcType mvcType)
        {
            return GetRandomFrom(mvcType, DefaultSeed);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcType"></param>
        /// <returns></returns>
        public static void RemoveRandom(MvcType mvcType)
        {
            MvcTypeRandoms.Remove(mvcType);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcType"></param>
        /// <param name="seed">   </param>
        /// <returns></returns>
        public static Random GetRandom(MvcType mvcType, int seed)
        {
            return GetRandomFrom(mvcType, seed);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcType"></param>
        /// <param name="seed">   </param>
        /// <returns></returns>
        private static Random GetRandomFrom(MvcType mvcType, int seed)
        {
            if (!MvcTypeRandoms.ContainsKey(mvcType))
            {
                MvcTypeRandoms.Add(mvcType, new Random(seed));
            }
            return MvcTypeRandoms[mvcType];
        }
    }
}