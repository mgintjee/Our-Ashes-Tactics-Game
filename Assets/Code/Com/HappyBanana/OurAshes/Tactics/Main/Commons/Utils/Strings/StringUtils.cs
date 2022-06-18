using System.Collections;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class StringUtils
    {
        private static readonly string NULL_STRING = "null";

        public static string Format(object obj)
        {
            string nameSpace = obj.GetType().Namespace;
            if (nameSpace.StartsWith("System") && !nameSpace.Contains("Collection"))
            {
                return obj.ToString();
            }
            else if (obj is IEnumerable enumerable)
            {
                return FormatEnumerable(enumerable);
            }
            else
            {
                return FormatObject(obj);
            }
        }

        private static string FormatEnumerable(IEnumerable enumberable)
        {
            IEnumerator enumerator = enumberable.GetEnumerator();
            string returnedString = string.Format("{0}:[{1}",
                enumberable.GetType().Name, (enumerator.MoveNext())
                    ? enumerator.Current
                    : NULL_STRING);
            while (enumerator.MoveNext())
            {
                returnedString += "," + enumerator.Current;
            }
            return returnedString + "]";
        }

        private static string FormatObject<TObject>(TObject tObject)
        {
            return string.Format("{0}:{1}",
                tObject.GetType().Name, (tObject != null)
                    ? tObject.ToString()
                    : NULL_STRING);
        }
    }
}