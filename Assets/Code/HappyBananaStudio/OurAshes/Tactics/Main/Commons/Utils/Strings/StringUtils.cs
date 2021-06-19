using System;
using System.Collections;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"> </param>
        /// <returns></returns>
        public static string Format(Type type, object obj)
        {
            return (obj is IEnumerable)
                ? FormatCollection(type, obj)
                : string.Format("{0}:{1}", type.Name, obj.ToString());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string FormatCollection(Type type, object collection)
        {
            return string.Format("Set {0}:[{1}]", type.Name, string.Join(", ", collection));
        }
    }
}