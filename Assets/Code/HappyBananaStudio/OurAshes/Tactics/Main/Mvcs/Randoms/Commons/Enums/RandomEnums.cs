using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Enums;
using System;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Commons.Enums
{
    /// <summary>
    /// Random Enums
    /// </summary>
    public static class RandomEnums
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="random"></param>
        /// <returns></returns>
        public static TEnum GenerateRandomEnum<TEnum>(Random random)
            where TEnum : Enum
        {
            IList<TEnum> tEnums = EnumUtils.GetEnumListWithoutFirst<TEnum>();
            return tEnums[random.Next(tEnums.Count)];
        }
    }
}