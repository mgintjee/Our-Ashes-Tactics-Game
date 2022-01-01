using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls;
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
        private static readonly IDictionary<ColorID, IRgb> ID_RGBS =
            new Dictionary<ColorID, IRgb>()
            {
                {ColorID.Black, new BlackRgbImpl() },
                {ColorID.White, new WhiteRgbImpl() },
                {ColorID.Red, new RedRgbImpl() },
                {ColorID.Lime, new LimeRgbImpl() },
                {ColorID.Blue, new BlueRgbImpl() },
                {ColorID.Yellow, new YellowRgbImpl() },
                {ColorID.Cyan, new CyanRgbImpl() },
                {ColorID.Fuchsia, new FuchsiaRgbImpl() },
                {ColorID.Silver, new SilverRgbImpl() },
                {ColorID.Gray, new GrayRgbImpl() },
                {ColorID.Maroon, new MaroonRgbImpl() },
                {ColorID.Olive, new OliveRgbImpl() },
                {ColorID.Green, new GreenRgbImpl() },
                {ColorID.Purple, new PurpleRgbImpl() },
                {ColorID.Teal, new TealRgbImpl() },
                {ColorID.Navy, new NavyRgbImpl() },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorID"></param>
        public static Color GetUnityColor(ColorID colorID)
        {
            return new Color(ID_RGBS[colorID].GetFloatRed(),
                ID_RGBS[colorID].GetFloatGreen(),
                ID_RGBS[colorID].GetFloatBlue());
        }
    }
}