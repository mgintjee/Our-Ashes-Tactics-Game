using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// RosyBrown Rgb Implementation
    /// </summary>
    public class RosyBrownImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RosyBrownImpl()
        {
            this.colorID = ColorID.RosyBrown;
            this.red = 188;
            this.green = 143;
            this.blue = 143;
        }
    }
}