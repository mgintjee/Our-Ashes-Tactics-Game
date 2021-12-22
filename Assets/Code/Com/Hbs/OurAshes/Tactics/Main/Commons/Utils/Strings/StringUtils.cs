using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static string FormatCollection<TObject>(ICollection<TObject> collection)
        {
            return string.Format("Collection {0}:[{1}]",
                typeof(TObject).Name, string.Join(", ", collection));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="tObject"></param>
        /// <returns></returns>
        public static string Format<TObject>(TObject tObject)
        {
            return string.Format("{0}:{1}",
                typeof(TObject).Name, (tObject != null) ? tObject.ToString() : "Null");
        }
    }
}