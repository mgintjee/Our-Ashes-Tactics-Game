using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Enums;
using System;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers
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
        /// <returns></returns>
        public static Random GetCentralRandom()
        {
            return GetRandom(MvcType.Central);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static Random GetCentralRandom(int seed)
        {
            return GetRandom(MvcType.Central, seed);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static Random GetSortieRandom()
        {
            return GetRandom(MvcType.Sortie);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static Random GetSortieRandom(int seed)
        {
            return GetRandom(MvcType.Sortie, seed);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static Random GetWorldRandom()
        {
            return GetRandom(MvcType.World);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static Random GetWorldRandom(int seed)
        {
            return GetRandom(MvcType.World, seed);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="classLogging"></param>
        /// <returns></returns>
        private static Random GetRandom(MvcType mvcType)
        {
            return GetRandom(mvcType, DefaultSeed);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcType"></param>
        /// <param name="seed">   </param>
        /// <returns></returns>
        private static Random GetRandom(MvcType mvcType, int seed)
        {
            if (!MvcTypeRandoms.ContainsKey(mvcType))
            {
                MvcTypeRandoms.Add(mvcType, new Random(seed));
            }
            return MvcTypeRandoms[mvcType];
        }
    }
}