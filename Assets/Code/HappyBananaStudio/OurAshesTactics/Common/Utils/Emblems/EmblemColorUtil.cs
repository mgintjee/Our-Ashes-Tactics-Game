/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Emblems
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class EmblemColorUtil
    {
        // Todo
        private static Dictionary<ColorIdEnum, Color> colorIdColorDictionary = new Dictionary<ColorIdEnum, Color>()
        {
            {ColorIdEnum.Aqua, new Color(0, 255, 255) },
            {ColorIdEnum.Black, new Color(0, 0, 0) },
            {ColorIdEnum.Blue, new Color(0, 0, 255) },
            {ColorIdEnum.Chocolate, new Color(210, 105, 30) },
            {ColorIdEnum.Gray, new Color(128,128,128) },
            {ColorIdEnum.Green, new Color(0,128,0) },
            {ColorIdEnum.Lime, new Color(0, 255, 0) },
            {ColorIdEnum.Magenta, new Color(255, 0, 255) },
            {ColorIdEnum.Maroon, new Color(128, 0, 0) },
            {ColorIdEnum.Navy, new Color(0, 0, 0) },
            {ColorIdEnum.Olive, new Color(0, 0, 0) },
            {ColorIdEnum.Orange, new Color(255, 165, 0) },
            {ColorIdEnum.Purple, new Color(128, 0, 128) },
            {ColorIdEnum.Red, new Color(255, 0, 0) },
            {ColorIdEnum.Teal, new Color(0, 128, 128) },
            {ColorIdEnum.White, new Color(255, 255, 255) },
            {ColorIdEnum.Yellow, new Color(255, 255, 0) },
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
            if (colorIdColorDictionary.ContainsKey(colorId))
            {
                color = colorIdColorDictionary[colorId];
            }
            return color;
        }
    }
}