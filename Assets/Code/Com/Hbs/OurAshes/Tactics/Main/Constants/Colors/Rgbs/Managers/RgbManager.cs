using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Inters;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Colors.Rgbs.Managers
{
    /// <summary>
    /// Names and RGB values pulled from https://www.rapidtables.com/web/color/RGB_Color.html
    /// </summary>
    public static class RgbManager
    {
        // Todo
        private static readonly IDictionary<ColorID, IRgb> IDRgbs =
            new Dictionary<ColorID, IRgb>()
            {
                {ColorID.Black, new BlackRgbImpl() },
                {ColorID.White, new WhiteRgbImpl() },
                {ColorID.Red, new RedRgbImpl() },
                {ColorID.Lime, new LimeRgbImpl() },
                {ColorID.Blue, new BlueRgbImpl() },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorID"></param>
        /// <returns></returns>
        public static Optional<IRgb> GetRgb(ColorID colorID)
        {
            return (IDRgbs.ContainsKey(colorID))
                ? Optional<IRgb>.Of((IDRgbs[colorID]))
                : Optional<IRgb>.Empty();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorID"></param>
        public static Color GetUnityColor(ColorID colorID)
        {
            Optional<IRgb> rgb = GetRgb(colorID);
            return (rgb.IsPresent())
                ? new Color(rgb.GetValue().GetFloatRed(),
                    rgb.GetValue().GetFloatGreen(),
                    rgb.GetValue().GetFloatBlue())
            : new Color();
        }
    }
}