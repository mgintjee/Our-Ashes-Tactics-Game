namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Utils.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

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
        public static IList<TEnum> GetEnumListWithoutFirst<TEnum>() where TEnum : Enum
        {
            IList<TEnum> enumList = GetEnumList<TEnum>();
            enumList.RemoveAt(0);
            return enumList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static TEnum GetRandomEnum<TEnum>() where TEnum : Enum
        {
            IList<TEnum> enumList = GetEnumListWithoutFirst<TEnum>();
            if (enumList.Count == 0)
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. Enum=? has 0 entries.",
                        new StackFrame().GetMethod().Name, typeof(TEnum));
            }
            return enumList[RandomNumberGeneratorUtil.GetNextInt(enumList.Count - 1)];
        }
    }
}