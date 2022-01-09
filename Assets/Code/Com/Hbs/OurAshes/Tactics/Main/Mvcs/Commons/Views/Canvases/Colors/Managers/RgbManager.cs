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
                {ColorID.Black, new BlackImpl() },
                {ColorID.White, new WhiteImpl() },
                {ColorID.Red, new RedImpl() },
                {ColorID.Lime, new LimeImpl() },
                {ColorID.Blue, new BlueImpl() },
                {ColorID.Yellow, new YellowImpl() },
                {ColorID.Cyan, new CyanImpl() },
                {ColorID.Fuchsia, new FuchsiaImpl() },
                {ColorID.Silver, new SilverImpl() },
                {ColorID.Gray, new GrayImpl() },
                {ColorID.Maroon, new MaroonImpl() },
                {ColorID.Olive, new OliveImpl() },
                {ColorID.Green, new GreenImpl() },
                {ColorID.Purple, new PurpleImpl() },
                {ColorID.Teal, new TealImpl() },
                {ColorID.Navy, new NavyImpl() },
            };

        public static IRgb GetRgb(ColorID colorID)
        {
            return ID_RGBS.ContainsKey(colorID)
                ? ID_RGBS[colorID]
                : ID_RGBS[ColorID.White];
        }

        public static Color GetUnityColor(ColorID colorID)
        {
            IRgb rgb = GetRgb(colorID);
            return new Color(rgb.GetFloatRed(), rgb.GetFloatGreen(), rgb.GetFloatBlue());
        }
    }
}