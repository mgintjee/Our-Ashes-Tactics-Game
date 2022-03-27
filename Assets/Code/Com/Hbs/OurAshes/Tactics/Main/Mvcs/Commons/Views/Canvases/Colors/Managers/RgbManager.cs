using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Inters;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Managers
{
    /// <summary>
    /// Names and RGB values pulled from https://www.rapidtables.com/web/color/RGB_Color.html
    /// </summary>
    public static class RgbManager
    {
        // Todo
        private static readonly IDictionary<ColorID, IRgb> ID_RGBS = RgbUtil.BuildRgbManagerDictionary();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorID"></param>
        /// <returns></returns>
        public static IRgb GetRgb(ColorID colorID)
        {
            return ID_RGBS.ContainsKey(colorID)
                ? ID_RGBS[colorID] : ID_RGBS[ColorID.White];
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorID"></param>
        /// <returns></returns>
        public static Color GetUnityColor(ColorID colorID)
        {
            IRgb rgb = GetRgb(colorID);
            return new Color(rgb.GetFloatRed(), rgb.GetFloatGreen(), rgb.GetFloatBlue());
        }
    }
}