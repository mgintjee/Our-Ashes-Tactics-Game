using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Colors.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Colors.Rgbs.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Colors.Rgbs.Inters;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Colors.Rgbs.Managers
{
    /// <summary>
    /// Names and RGB values pulled from https://www.rapidtables.com/web/color/RGB_Color.html
    /// </summary>
    public static class RgbsManager
    {
        // Todo
        private static readonly IDictionary<ColorID, IRgb> IDRgbs =
            new Dictionary<ColorID, IRgb>()
            {
                { ColorID.Maroon, Rgb.Builder.Get().SetRed(220).SetBlue(20).SetGreen(60).Build() },
                { ColorID.Crimson,  Rgb.Builder.Get().SetRed(220).SetBlue( 20).SetGreen( 60).Build() },
                { ColorID.Red, Rgb.Builder.Get().SetRed(255).SetBlue( 0).SetGreen( 0).Build() },
                { ColorID.Tomato, Rgb.Builder.Get().SetRed(255).SetBlue( 99).SetGreen( 71).Build() },
                { ColorID.Coral, Rgb.Builder.Get().SetRed(255).SetBlue( 127).SetGreen( 80).Build() },
                { ColorID.IndianRed, Rgb.Builder.Get().SetRed(205).SetBlue( 92).SetGreen( 92).Build() },
                { ColorID.LightSalmon, Rgb.Builder.Get().SetRed(255).SetBlue( 160).SetGreen( 122).Build() },
                { ColorID.OrangeRed, Rgb.Builder.Get().SetRed(255).SetBlue( 69).SetGreen( 0).Build() },
                { ColorID.DarkOrange,Rgb.Builder.Get().SetRed(255).SetBlue( 0).SetGreen( 0).Build()},
                { ColorID.Gold,Rgb.Builder.Get().SetRed(255).SetBlue( 215).SetGreen( 0).Build()},
                { ColorID.GoldenRod,Rgb.Builder.Get().SetRed(218).SetBlue( 165).SetGreen( 32).Build()},
                { ColorID.Khaki,Rgb.Builder.Get().SetRed(240).SetBlue( 230).SetGreen( 140).Build()},
                { ColorID.Olive,Rgb.Builder.Get().SetRed(128).SetBlue( 128).SetGreen( 0).Build()},
                { ColorID.Yellow,Rgb.Builder.Get().SetRed(255).SetBlue( 255).SetGreen( 0).Build()},
                { ColorID.ChartReuse,Rgb.Builder.Get().SetRed(127).SetBlue( 255).SetGreen( 0).Build()},
                { ColorID.DarkGreen,Rgb.Builder.Get().SetRed(0).SetBlue( 100).SetGreen( 0).Build()},
                { ColorID.ForestGreen,Rgb.Builder.Get().SetRed(34).SetBlue( 139).SetGreen( 34).Build()},
                { ColorID.Lime,Rgb.Builder.Get().SetRed(0).SetBlue( 255).SetGreen( 0).Build()},
                { ColorID.PaleGreen,Rgb.Builder.Get().SetRed(152).SetBlue( 251).SetGreen( 152).Build()},
                { ColorID.SpringGreen,Rgb.Builder.Get().SetRed(0).SetBlue( 255).SetGreen( 127).Build()},
                { ColorID.SeaGreen,Rgb.Builder.Get().SetRed(46).SetBlue( 139).SetGreen( 87).Build()},
                { ColorID.LightSeaGreen,Rgb.Builder.Get().SetRed(32).SetBlue( 178).SetGreen( 170).Build()},
                { ColorID.Teal,Rgb.Builder.Get().SetRed(0).SetBlue( 128).SetGreen( 128).Build()},
                { ColorID.Aqua,Rgb.Builder.Get().SetRed(0).SetBlue( 255).SetGreen( 255).Build()},
                { ColorID.Turquoise,Rgb.Builder.Get().SetRed(64).SetBlue( 224).SetGreen( 208).Build()},
                { ColorID.AquaMarine,Rgb.Builder.Get().SetRed(127).SetBlue(255).SetGreen(212).Build()},
                { ColorID.SteelBlue,Rgb.Builder.Get().SetRed(70).SetBlue( 130).SetGreen( 180).Build()},
                { ColorID.CornFlowerBlue,Rgb.Builder.Get().SetRed(100).SetBlue( 149).SetGreen( 237).Build()},
                { ColorID.DodgerBlue,Rgb.Builder.Get().SetRed(30).SetBlue( 144).SetGreen( 255).Build()},
                { ColorID.LightBlue,Rgb.Builder.Get().SetRed(173).SetBlue( 216).SetGreen( 230).Build()},
                { ColorID.LightSkyBlue,Rgb.Builder.Get().SetRed(135).SetBlue( 206).SetGreen( 250).Build()},
                { ColorID.MidnightBlue,Rgb.Builder.Get().SetRed(25).SetBlue( 25).SetGreen( 112).Build()},
                { ColorID.Navy,Rgb.Builder.Get().SetRed(0).SetBlue( 0).SetGreen( 128).Build()},
                { ColorID.Blue,Rgb.Builder.Get().SetRed(0).SetBlue( 0).SetGreen( 255).Build()},
                { ColorID.RoyalBlue,Rgb.Builder.Get().SetRed(65).SetBlue( 105).SetGreen( 255).Build()},
                { ColorID.BlueViolet,Rgb.Builder.Get().SetRed(138).SetBlue( 43).SetGreen( 226).Build()},
                { ColorID.Indigo,Rgb.Builder.Get().SetRed(75).SetBlue( 0).SetGreen( 130).Build()},
                { ColorID.SlateBlue,Rgb.Builder.Get().SetRed(106).SetBlue( 90).SetGreen( 205).Build()},
                { ColorID.DarkOrchid,Rgb.Builder.Get().SetRed(153).SetBlue( 50).SetGreen( 204).Build()},
                { ColorID.Purple,Rgb.Builder.Get().SetRed(128).SetBlue( 0).SetGreen( 128).Build()},
                { ColorID.Thistle,Rgb.Builder.Get().SetRed(216).SetBlue( 191).SetGreen( 216).Build()},
                { ColorID.Violet,Rgb.Builder.Get().SetRed(238).SetBlue( 130).SetGreen( 238).Build()},
                { ColorID.Magenta,Rgb.Builder.Get().SetRed(255).SetBlue( 0).SetGreen( 255).Build()},
                { ColorID.Orchid,Rgb.Builder.Get().SetRed(218).SetBlue( 112).SetGreen( 214).Build()},
                { ColorID.HotPink,Rgb.Builder.Get().SetRed(255).SetBlue( 105).SetGreen( 180).Build()},
                { ColorID.Pink,Rgb.Builder.Get().SetRed(255).SetBlue( 192).SetGreen( 203).Build()},
                { ColorID.Beige,Rgb.Builder.Get().SetRed(245).SetBlue( 245).SetGreen( 220).Build()},
                { ColorID.Wheat,Rgb.Builder.Get().SetRed(245).SetBlue( 222).SetGreen( 179).Build()},
                { ColorID.SaddleBrown,Rgb.Builder.Get().SetRed(139).SetBlue( 69).SetGreen( 19).Build()},
                { ColorID.Chocolate,Rgb.Builder.Get().SetRed(210).SetBlue( 105).SetGreen( 30).Build()},
                { ColorID.SandyBrown,Rgb.Builder.Get().SetRed(244).SetBlue( 164).SetGreen( 96).Build()},
                { ColorID.Tan,Rgb.Builder.Get().SetRed(210).SetBlue( 180).SetGreen( 140).Build()},
                { ColorID.SlateGray, Rgb.Builder.Get().SetRed(112).SetBlue( 128).SetGreen( 144).Build() },
                { ColorID.LightSlateGray,Rgb.Builder.Get().SetRed(119).SetBlue( 136).SetGreen( 153).Build() },
                { ColorID.LightSteelBlue, Rgb.Builder.Get().SetRed(176).SetBlue( 196).SetGreen( 222).Build() },
                { ColorID.Black, Rgb.Builder.Get().SetRed(0).SetBlue( 0).SetGreen( 0).Build() },
                { ColorID.DimGray, Rgb.Builder.Get().SetRed(105).SetBlue( 105).SetGreen( 105).Build() },
                { ColorID.Gray, Rgb.Builder.Get().SetRed(128).SetBlue( 128).SetGreen( 128).Build() },
                { ColorID.Silver, Rgb.Builder.Get().SetRed(192).SetBlue( 192).SetGreen( 192).Build() },
                { ColorID.LightGray, Rgb.Builder.Get().SetRed(211).SetBlue( 211).SetGreen( 211).Build() },
                { ColorID.WhiteSmoke, Rgb.Builder.Get().SetRed(245).SetBlue( 245).SetGreen( 245).Build() },
                { ColorID.White, Rgb.Builder.Get().SetRed(255).SetBlue( 255).SetGreen( 255).Build() }
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