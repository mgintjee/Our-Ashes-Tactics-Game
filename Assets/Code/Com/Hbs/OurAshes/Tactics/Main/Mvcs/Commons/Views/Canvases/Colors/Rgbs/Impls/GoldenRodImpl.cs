using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// GoldenRod Rgb Implementation
    /// </summary>
    public class GoldenRodImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GoldenRodImpl()
        {
            this.colorID = ColorID.GoldenRod;
            this.red = 218;
            this.green = 165;
            this.blue = 32;
        }
    }
}