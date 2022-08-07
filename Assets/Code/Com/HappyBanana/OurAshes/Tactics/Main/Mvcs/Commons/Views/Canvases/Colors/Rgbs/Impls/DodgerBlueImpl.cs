using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// DodgerBlue Rgb Implementation
    /// </summary>
    public class DodgerBlueImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DodgerBlueImpl()
        {
            this.colorID = ColorID.DodgerBlue;
            this.red = 30;
            this.green = 144;
            this.blue = 255;
        }
    }
}