using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class EnumUtils
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IList<TEnum> GetEnumList<TEnum>() where TEnum : Enum
        {
            return ((TEnum[])Enum.GetValues(typeof(TEnum))).ToList();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IList<TEnum> GetEnumListWithoutFirst<TEnum>()
            where TEnum : Enum
        {
            IList<TEnum> enumList = GetEnumList<TEnum>();
            enumList.RemoveAt(0);
            return enumList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="end"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IList<TEnum> GetEnumList<TEnum>(int end) where TEnum : Enum
        {
            IList<TEnum> tEnums = GetEnumListWithoutFirst<TEnum>();
            if (tEnums.Count < end)
            {
                end = tEnums.Count;
            }
            return ((List<TEnum>)tEnums).GetRange(0, end);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="random"></param>
        /// <returns></returns>
        public static TEnum GenerateRandomEnum<TEnum>(Random random)
            where TEnum : Enum
        {
            IList<TEnum> tEnums = GetEnumListWithoutFirst<TEnum>();
            return tEnums[random.Next(tEnums.Count)];
        }

        public static IList<string> GetEnumsAsStrings<TEnum>(IList<TEnum> enums)
        {
            List<string> strings = new List<string>();
            foreach (TEnum tEnum in enums)
            {
                strings.Add(tEnum.ToString());
            }
            return strings;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="random"></param>
        /// <returns></returns>
        public static TEnum GenerateRandomEnumFrom<TEnum>(Random random, ISet<TEnum> enums)
            where TEnum : Enum
        {
            IList<TEnum> tEnums = new List<TEnum>(enums);
            return tEnums[random.Next(tEnums.Count)];
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="random"></param>
        /// <param name="count"> </param>
        /// <returns></returns>
        public static ISet<TEnum> GenerateRandomEnumsFrom<TEnum>(Random random, ISet<TEnum> availableEnums, int count)
            where TEnum : Enum
        {
            ISet<TEnum> tEnums = new HashSet<TEnum>();
            ISet<TEnum> tempAvailableEnums = new HashSet<TEnum>(availableEnums);
            while (tEnums.Count < count && tEnums.Count < availableEnums.Count)
            {
                TEnum tEnum = GenerateRandomEnumFrom(random, tempAvailableEnums);
                tempAvailableEnums.Remove(tEnum);
                tEnums.Add(tEnum);
            }

            return tEnums;
        }

        public static TEnum DetermineEnumFrom<TEnum>(string str)
            where TEnum : Enum
        {
            IList<TEnum> tEnums = GetEnumList<TEnum>();
            foreach (TEnum tEnum in tEnums)
            {
                if (str.Contains(tEnum.ToString()))
                {
                    return tEnum;
                }
            }
            return tEnums[0];
        }
    }
}