using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class RgbUtil
    {
        public static IDictionary<ColorID, IRgb> BuildRgbManagerDictionary()
        {
            ISet<IRgb> rgbs = new HashSet<IRgb>()
            {
                new BlackImpl(),
                new BlueImpl(),
                new CyanImpl(),
                new DeepPinkImpl(),
                new DodgerBlueImpl(),
                new FuchsiaImpl(),
                new GainsboroImpl(),
                new GoldenRodImpl(),
                new GrayImpl(),
                new GreenImpl(),
                new HoneydewImpl(),
                new IndigoImpl(),
                new LimeImpl(),
                new MaroonImpl(),
                new MidnightBlueImpl(),
                new NavyImpl(),
                new OliveImpl(),
                new PurpleImpl(),
                new RedImpl(),
                new RosyBrownImpl(),
                new SalmonImpl(),
                new SiennaImpl(),
                new SilverImpl(),
                new SlateGrayImpl(),
                new SpringGreenImpl(),
                new TealImpl(),
                new ThistleImpl(),
                new WhiteImpl(),
                new YellowImpl()
            };
            IDictionary<ColorID, IRgb> colorIDRgbs = new Dictionary<ColorID, IRgb>();

            foreach (IRgb rgb in rgbs)
            {
                colorIDRgbs.Add(rgb.GetColorID(), rgb);
            }

            return colorIDRgbs;
        }
    }
}