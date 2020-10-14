

namespace HappyBananaStudio.OurAshes.Tactics.Common.Utils.Emblems
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Color;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public static class EmblemColorUtil
    {
        // Todo
        private static readonly IDictionary<ColorIdEnum, Color> colorIdColorIDictionary = new Dictionary<ColorIdEnum, Color>()
        {
            {ColorIdEnum.Aqua, new Color(0, 1, 1) },
            {ColorIdEnum.Black, new Color(0, 0, 0) },
            {ColorIdEnum.Blue, new Color(0, 0, 1) },
            {ColorIdEnum.Chocolate, new Color(210/255f, 105/255f, 30/255f) },
            {ColorIdEnum.Gray, new Color(128/255f,128/255f,128/255f) },
            {ColorIdEnum.Green, new Color(0,128/255f,0) },
            {ColorIdEnum.Lime, new Color(0, 1, 0) },
            {ColorIdEnum.Magenta, new Color(1, 0, 1) },
            {ColorIdEnum.Maroon, new Color(128/255f, 0, 0) },
            {ColorIdEnum.Navy, new Color(0, 0, 128/255f) },
            {ColorIdEnum.Olive, new Color(128/255f, 128/255f, 0) },
            {ColorIdEnum.Orange, new Color(1, 165/255f, 0) },
            {ColorIdEnum.Purple, new Color(128/255f, 0, 128/255f) },
            {ColorIdEnum.Red, new Color(1, 0, 0) },
            {ColorIdEnum.Teal, new Color(0, 128/255f, 128/255f) },
            {ColorIdEnum.White, new Color(1, 1, 1) },
            {ColorIdEnum.Yellow, new Color(1,1, 0) },
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorId">
        /// </param>
        /// <returns>
        /// </returns>
        public static Color GetColor(ColorIdEnum colorId)
        {
            Color color = new Color();
            if (colorIdColorIDictionary.ContainsKey(colorId))
            {
                color = colorIdColorIDictionary[colorId];
            }
            return color;
        }
    }
}
