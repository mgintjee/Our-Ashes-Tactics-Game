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
                { ColorID.Maroon, RgbImpl.Builder.Get().SetRed(220).SetBlue(20).SetGreen(60).Build() },
                { ColorID.Crimson,  RgbImpl.Builder.Get().SetRed(220).SetBlue( 20).SetGreen( 60).Build() },
                { ColorID.Red, RgbImpl.Builder.Get().SetRed(255).SetBlue( 0).SetGreen( 0).Build() },
                { ColorID.Tomato, RgbImpl.Builder.Get().SetRed(255).SetBlue( 99).SetGreen( 71).Build() },
                { ColorID.Coral, RgbImpl.Builder.Get().SetRed(255).SetBlue( 127).SetGreen( 80).Build() },
                { ColorID.IndianRed, RgbImpl.Builder.Get().SetRed(205).SetBlue( 92).SetGreen( 92).Build() },
                { ColorID.LightSalmon, RgbImpl.Builder.Get().SetRed(255).SetBlue( 160).SetGreen( 122).Build() },
                { ColorID.OrangeRed, RgbImpl.Builder.Get().SetRed(255).SetBlue( 69).SetGreen( 0).Build() },
                { ColorID.DarkOrange,RgbImpl.Builder.Get().SetRed(255).SetBlue( 0).SetGreen( 0).Build()},
                { ColorID.Gold,RgbImpl.Builder.Get().SetRed(255).SetBlue( 215).SetGreen( 0).Build()},
                { ColorID.GoldenRod,RgbImpl.Builder.Get().SetRed(218).SetBlue( 165).SetGreen( 32).Build()},
                { ColorID.Khaki,RgbImpl.Builder.Get().SetRed(240).SetBlue( 230).SetGreen( 140).Build()},
                { ColorID.Olive,RgbImpl.Builder.Get().SetRed(128).SetBlue( 128).SetGreen( 0).Build()},
                { ColorID.Yellow,RgbImpl.Builder.Get().SetRed(255).SetBlue( 255).SetGreen( 0).Build()},
                { ColorID.ChartReuse,RgbImpl.Builder.Get().SetRed(127).SetBlue( 255).SetGreen( 0).Build()},
                { ColorID.DarkGreen,RgbImpl.Builder.Get().SetRed(0).SetBlue( 0).SetGreen( 100).Build()},
                { ColorID.ForestGreen,RgbImpl.Builder.Get().SetRed(34).SetBlue( 139).SetGreen( 34).Build()},
                { ColorID.Lime,RgbImpl.Builder.Get().SetRed(0).SetBlue( 255).SetGreen( 0).Build()},
                { ColorID.PaleGreen,RgbImpl.Builder.Get().SetRed(152).SetBlue( 251).SetGreen( 152).Build()},
                { ColorID.SpringGreen,RgbImpl.Builder.Get().SetRed(0).SetBlue( 255).SetGreen( 127).Build()},
                { ColorID.SeaGreen,RgbImpl.Builder.Get().SetRed(46).SetBlue( 139).SetGreen( 87).Build()},
                { ColorID.LightSeaGreen,RgbImpl.Builder.Get().SetRed(32).SetBlue( 178).SetGreen( 170).Build()},
                { ColorID.Teal,RgbImpl.Builder.Get().SetRed(0).SetBlue( 128).SetGreen( 128).Build()},
                { ColorID.Aqua,RgbImpl.Builder.Get().SetRed(0).SetBlue( 255).SetGreen( 255).Build()},
                { ColorID.Turquoise,RgbImpl.Builder.Get().SetRed(64).SetBlue( 224).SetGreen( 208).Build()},
                { ColorID.AquaMarine,RgbImpl.Builder.Get().SetRed(127).SetBlue(255).SetGreen(212).Build()},
                { ColorID.SteelBlue,RgbImpl.Builder.Get().SetRed(70).SetBlue( 130).SetGreen( 180).Build()},
                { ColorID.CornFlowerBlue,RgbImpl.Builder.Get().SetRed(100).SetBlue( 149).SetGreen( 237).Build()},
                { ColorID.DodgerBlue,RgbImpl.Builder.Get().SetRed(30).SetBlue( 144).SetGreen( 255).Build()},
                { ColorID.LightBlue,RgbImpl.Builder.Get().SetRed(173).SetBlue( 216).SetGreen( 230).Build()},
                { ColorID.LightSkyBlue,RgbImpl.Builder.Get().SetRed(135).SetBlue( 206).SetGreen( 250).Build()},
                { ColorID.MidnightBlue,RgbImpl.Builder.Get().SetRed(25).SetBlue( 25).SetGreen( 112).Build()},
                { ColorID.Navy,RgbImpl.Builder.Get().SetRed(0).SetBlue( 0).SetGreen( 128).Build()},
                { ColorID.Blue,RgbImpl.Builder.Get().SetRed(0).SetBlue( 0).SetGreen( 255).Build()},
                { ColorID.RoyalBlue,RgbImpl.Builder.Get().SetRed(65).SetBlue( 105).SetGreen( 255).Build()},
                { ColorID.BlueViolet,RgbImpl.Builder.Get().SetRed(138).SetBlue( 43).SetGreen( 226).Build()},
                { ColorID.Indigo,RgbImpl.Builder.Get().SetRed(75).SetBlue( 0).SetGreen( 130).Build()},
                { ColorID.SlateBlue,RgbImpl.Builder.Get().SetRed(106).SetBlue( 90).SetGreen( 205).Build()},
                { ColorID.DarkOrchid,RgbImpl.Builder.Get().SetRed(153).SetBlue( 50).SetGreen( 204).Build()},
                { ColorID.Purple,RgbImpl.Builder.Get().SetRed(128).SetBlue( 0).SetGreen( 128).Build()},
                { ColorID.Thistle,RgbImpl.Builder.Get().SetRed(216).SetBlue( 191).SetGreen( 216).Build()},
                { ColorID.Violet,RgbImpl.Builder.Get().SetRed(238).SetBlue( 130).SetGreen( 238).Build()},
                { ColorID.Magenta,RgbImpl.Builder.Get().SetRed(255).SetBlue( 0).SetGreen( 255).Build()},
                { ColorID.Orchid,RgbImpl.Builder.Get().SetRed(218).SetBlue( 112).SetGreen( 214).Build()},
                { ColorID.HotPink,RgbImpl.Builder.Get().SetRed(255).SetBlue( 105).SetGreen( 180).Build()},
                { ColorID.Pink,RgbImpl.Builder.Get().SetRed(255).SetBlue( 192).SetGreen( 203).Build()},
                { ColorID.Beige,RgbImpl.Builder.Get().SetRed(245).SetBlue( 245).SetGreen( 220).Build()},
                { ColorID.Wheat,RgbImpl.Builder.Get().SetRed(245).SetBlue( 222).SetGreen( 179).Build()},
                { ColorID.SaddleBrown,RgbImpl.Builder.Get().SetRed(139).SetBlue( 69).SetGreen( 19).Build()},
                { ColorID.Chocolate,RgbImpl.Builder.Get().SetRed(210).SetBlue( 105).SetGreen( 30).Build()},
                { ColorID.SandyBrown,RgbImpl.Builder.Get().SetRed(244).SetBlue( 164).SetGreen( 96).Build()},
                { ColorID.Tan,RgbImpl.Builder.Get().SetRed(210).SetBlue( 180).SetGreen( 140).Build()},
                { ColorID.SlateGray, RgbImpl.Builder.Get().SetRed(112).SetBlue( 128).SetGreen( 144).Build() },
                { ColorID.LightSlateGray,RgbImpl.Builder.Get().SetRed(119).SetBlue( 136).SetGreen( 153).Build() },
                { ColorID.LightSteelBlue, RgbImpl.Builder.Get().SetRed(176).SetBlue( 196).SetGreen( 222).Build() },
                { ColorID.Black, RgbImpl.Builder.Get().SetRed(0).SetBlue( 0).SetGreen( 0).Build() },
                { ColorID.DimGray, RgbImpl.Builder.Get().SetRed(105).SetBlue( 105).SetGreen( 105).Build() },
                { ColorID.Gray, RgbImpl.Builder.Get().SetRed(128).SetBlue( 128).SetGreen( 128).Build() },
                { ColorID.Silver, RgbImpl.Builder.Get().SetRed(192).SetBlue( 192).SetGreen( 192).Build() },
                { ColorID.LightGray, RgbImpl.Builder.Get().SetRed(211).SetBlue( 211).SetGreen( 211).Build() },
                { ColorID.WhiteSmoke, RgbImpl.Builder.Get().SetRed(245).SetBlue( 245).SetGreen( 245).Build() },
                { ColorID.White, RgbImpl.Builder.Get().SetRed(255).SetBlue( 255).SetGreen( 255).Build() }
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