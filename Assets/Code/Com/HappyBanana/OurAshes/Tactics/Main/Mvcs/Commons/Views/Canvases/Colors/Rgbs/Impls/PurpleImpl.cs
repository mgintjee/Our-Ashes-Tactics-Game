using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Purple Rgb Implementation
    /// </summary>
    public class PurpleImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PurpleImpl()
        {
            this.colorID = ColorID.Purple;
            this.red = 128;
            this.green = 0;
            this.blue = 128;
        }
    }
}