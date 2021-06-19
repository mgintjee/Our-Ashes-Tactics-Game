using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Enums
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
    }
}