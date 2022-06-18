using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Gray Rgb Implementation
    /// </summary>
    public class GrayImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GrayImpl()
        {
            this.colorID = ColorID.Gray;
            this.red = 128;
            this.green = 128;
            this.blue = 128;
        }
    }
}