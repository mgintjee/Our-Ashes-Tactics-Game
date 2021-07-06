using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.Rgbs.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.Rgbs.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.Rgbs.Managers
{
    /// <summary>
    /// Names and RGB values pulled from https://www.rapidtables.com/web/color/RGB_Color.html
    /// </summary>
    public static class RgbsManager
    {
        // Todo
        private static readonly IDictionary<ColorID, IRgb> ColorIdRgbDictionary =
            new Dictionary<ColorID, IRgb>()
            {
                { ColorID.Maroon, new Rgb(128, 0, 0) },
                { ColorID.Crimson, new Rgb(220, 20, 60) },
                { ColorID.Red, new Rgb(255, 0, 0) },
                { ColorID.Tomato, new Rgb(255, 99, 71) },
                { ColorID.Coral, new Rgb(255, 127, 80) },
                { ColorID.IndianRed, new Rgb(205, 92, 92) },
                { ColorID.LightSalmon, new Rgb(255, 160, 122) },
                { ColorID.OrangeRed, new Rgb(255, 69, 0) },
                { ColorID.DarkOrange, new Rgb(255, 0, 0) },
                { ColorID.Gold, new Rgb(255, 215, 0) },
                { ColorID.GoldenRod, new Rgb(218, 165, 32) },
                { ColorID.Khaki, new Rgb(240, 230, 140) },
                { ColorID.Olive, new Rgb(128, 128, 0) },
                { ColorID.Yellow, new Rgb(255, 255, 0) },
                { ColorID.ChartReuse, new Rgb(127, 255, 0) },
                { ColorID.DarkGreen, new Rgb(0, 100, 0) },
                { ColorID.ForestGreen, new Rgb(34, 139, 34) },
                { ColorID.Lime, new Rgb(0, 255, 0) },
                { ColorID.PaleGreen, new Rgb(152, 251, 152) },
                { ColorID.SpringGreen, new Rgb(0, 255, 127) },
                { ColorID.SeaGreen, new Rgb(46, 139, 87) },
                { ColorID.LightSeaGreen, new Rgb(32, 178, 170) },
                { ColorID.Teal, new Rgb(0, 128, 128) },
                { ColorID.Aqua, new Rgb(0, 255, 255) },
                { ColorID.Turquoise, new Rgb(64, 224, 208) },
                { ColorID.AquaMarine, new Rgb(127 , 255, 212) },
                { ColorID.SteelBlue, new Rgb(70, 130, 180) },
                { ColorID.CornFlowerBlue, new Rgb(100, 149, 237) },
                { ColorID.DodgerBlue, new Rgb(30, 144, 255) },
                { ColorID.LightBlue, new Rgb(173, 216, 230) },
                { ColorID.LightSkyBlue, new Rgb(135, 206, 250) },
                { ColorID.MidnightBlue, new Rgb(25, 25, 112) },
                { ColorID.Navy, new Rgb(0, 0, 128) },
                { ColorID.Blue, new Rgb(0, 0, 255) },
                { ColorID.RoyalBlue, new Rgb(65, 105, 255) },
                { ColorID.BlueViolet, new Rgb(138, 43, 226) },
                { ColorID.Indigo, new Rgb(75, 0, 130) },
                { ColorID.SlateBlue, new Rgb(106, 90, 205) },
                { ColorID.DarkOrchid, new Rgb(153, 50, 204) },
                { ColorID.Purple, new Rgb(128, 0, 128) },
                { ColorID.Thistle, new Rgb(216, 191, 216) },
                { ColorID.Violet, new Rgb(238, 130, 238) },
                { ColorID.Magenta, new Rgb(255, 0, 255) },
                { ColorID.Orchid, new Rgb(218, 112, 214) },
                { ColorID.HotPink, new Rgb(255, 105, 180) },
                { ColorID.Pink, new Rgb(255, 192, 203) },
                { ColorID.Beige, new Rgb(245, 245, 220) },
                { ColorID.Wheat, new Rgb(245, 222, 179) },
                { ColorID.SaddleBrown, new Rgb(139, 69, 19) },
                { ColorID.Chocolate, new Rgb(210, 105, 30) },
                { ColorID.SandyBrown, new Rgb(244, 164, 96) },
                { ColorID.Tan, new Rgb(210, 180, 140) },
                { ColorID.SlateGray, new Rgb(112, 128, 144) },
                { ColorID.LightSlateGray, new Rgb(119, 136, 153) },
                { ColorID.LightSteelBlue, new Rgb(176, 196, 222) },
                { ColorID.Black, new Rgb(0, 0, 0) },
                { ColorID.DimGray, new Rgb(105, 105, 105) },
                { ColorID.Gray, new Rgb(128, 128, 128) },
                { ColorID.Silver, new Rgb(192, 192, 192) },
                { ColorID.LightGray, new Rgb(211, 211, 211) },
                { ColorID.WhiteSmoke, new Rgb(245, 245, 245) },
                { ColorID.White, new Rgb(255, 255, 255) }
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorID"></param>
        /// <returns></returns>
        public static IRgb GetRgb(ColorID colorID)
        {
            // Check if the colorID is supported
            if (ColorIdRgbDictionary.ContainsKey(colorID))
            {
                return ColorIdRgbDictionary[colorID];
            }
            throw ExceptionUtil.Arguments.Build("Unable to {}. Invalid Parameters. {} is not supported.",
                new StackFrame().GetMethod().Name, colorID);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorID"></param>
        public static Color GetUnityColor(ColorID colorID)
        {
            IRgb rgb = GetRgb(colorID);
            return new Color(rgb.GetFloatRed(), rgb.GetFloatGreen(), rgb.GetFloatBlue());
        }
    }
}