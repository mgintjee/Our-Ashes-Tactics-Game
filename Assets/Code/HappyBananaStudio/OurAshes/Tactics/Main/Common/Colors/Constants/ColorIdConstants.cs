namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public static class ColorIdConstants
    {
        // Todo
        private static readonly IDictionary<ColorId, RGB> colorRGBDictionary =
            new Dictionary<ColorId, RGB>()
            {
                {ColorId.Maroon, new RGB(128, 0, 0)},
                {ColorId.Crimson, new RGB(220, 20, 60)},
                {ColorId.Red, new RGB(255, 0, 0)},
                {ColorId.Coral, new RGB(255,127,80)},
                {ColorId.OrangeRed, new RGB(255,69,0)},
                {ColorId.DarkOrange, new RGB(255, 0, 0)},
                {ColorId.Gold, new RGB(255,215,0)},
                {ColorId.Khaki, new RGB(240,230,140)},
                {ColorId.Olive, new RGB(128,128,0)},
                {ColorId.Yellow, new RGB(255,255,0)},
                {ColorId.ChartReuse, new RGB(127,255,0)},
                {ColorId.Green, new RGB(0, 128, 0)},
                {ColorId.Lime, new RGB(0,255, 0)},
                {ColorId.SeaGreen, new RGB(46,139,87)},
                {ColorId.Teal, new RGB(0,128,128)},
                {ColorId.Aqua, new RGB(0,255,255)},
                {ColorId.DodgerBlue, new RGB(30,144,255)},
                {ColorId.LightSkyBlue, new RGB(135,206,250)},
                {ColorId.Navy, new RGB(0,0,128)},
                {ColorId.Blue, new RGB(0, 0,255)},
                {ColorId.Indigo, new RGB(75,0,130)},
                {ColorId.SlateBlue, new RGB(106,90,205)},
                {ColorId.Purple, new RGB(128,0,128)},
                {ColorId.Thistle, new RGB(216,191,216)},
                {ColorId.Magenta, new RGB(255,0,255)},
                {ColorId.HotPink, new RGB(255,105,180)},
                {ColorId.Pink, new RGB(255,192,203)},
                {ColorId.Beige, new RGB(245,245,220)},
                {ColorId.SaddleBrown, new RGB(139,69,19)},
                {ColorId.Chocolate, new RGB(210,105,30)},
                {ColorId.Tan, new RGB(210,180,140)},
                {ColorId.LightSlateGray, new RGB(119,136,153)},
                {ColorId.LightSteelBlue, new RGB(176,196,222)},
                {ColorId.DimGray, new RGB(105,105,105)},
                {ColorId.Gray, new RGB(128,128,128)},
                {ColorId.Silver, new RGB(192,192,192)},
                {ColorId.Black, new RGB(0,0,0)},
                {ColorId.White, new RGB(255,255,255)}
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorId"></param>
        public static Color GetColor(ColorId colorId)
        {
            // Check if the colorId is supported
            if (colorRGBDictionary.ContainsKey(colorId))
            {
                RGB rgb = colorRGBDictionary[colorId];
                return new Color(rgb.GetRed() / 255f, rgb.GetGreen() / 255f, rgb.GetBlue() / 255f);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, colorId);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private class RGB
        {
            // Todo
            private readonly int red;

            // Todo
            private readonly int green;

            // Todo
            private readonly int blue;

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="red"></param>
            /// <param name="green"></param>
            /// <param name="blue"></param>
            public RGB(int red, int green, int blue)
            {
                this.red = red;
                this.green = green;
                this.blue = blue;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public int GetRed()
            {
                return this.red;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public int GetGreen()
            {
                return this.green;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public int GetBlue()
            {
                return this.blue;
            }
        }
    }
}