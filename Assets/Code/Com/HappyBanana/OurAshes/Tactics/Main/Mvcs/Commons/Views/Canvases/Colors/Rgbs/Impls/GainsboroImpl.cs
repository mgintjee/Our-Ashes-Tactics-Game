using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Gainsboro Rgb Implementation
    /// </summary>
    public class GainsboroImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GainsboroImpl()
        {
            this.colorID = ColorID.Gainsboro;
            this.red = 220;
            this.green = 220;
            this.blue = 220;
        }
    }
}