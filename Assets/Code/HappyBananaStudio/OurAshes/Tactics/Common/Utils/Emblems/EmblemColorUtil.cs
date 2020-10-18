namespace HappyBananaStudio.OurAshes.Tactics.Common.Utils.Emblems
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Color;
    using HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public static class EmblemColorUtil
    {
        // Todo
        private static readonly IDictionary<ColorIdEnum, Color> ColorIdColorDictionary = new Dictionary<ColorIdEnum, Color>();

        // Todo
        private static readonly HashSet<ColorIdEnum> SupportedColorIdSet = new HashSet<ColorIdEnum>(
            new List<ColorIdEnum>(
                (ColorIdEnum[])Enum.GetValues(typeof(ColorIdEnum))
                )
            .Where(colorId => !colorId.Equals(ColorIdEnum.None)).ToList()
            );

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorId">
        /// </param>
        /// <returns>
        /// </returns>
        public static Color GetColor(ColorIdEnum colorId)
        {
            if (SupportedColorIdSet.Contains(colorId))
            {
                if (!ColorIdColorDictionary.ContainsKey(colorId))
                {
                    Color color = MaterialResourceLoader.Color.LoadColorMaterialResource(colorId).color;
                    color.a = 0.5f;
                    ColorIdColorDictionary.Add(colorId, color);
                }
                return ColorIdColorDictionary[colorId];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is not supported.", new StackFrame().GetMethod().Name, colorId);
            }
        }
    }
}
