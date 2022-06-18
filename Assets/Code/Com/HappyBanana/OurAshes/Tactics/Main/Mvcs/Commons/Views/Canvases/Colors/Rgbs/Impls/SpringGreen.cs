using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// SpringGreen Rgb Implementation
    /// </summary>
    public class SpringGreenImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SpringGreenImpl()
        {
            this.colorID = ColorID.SpringGreen;
            this.red = 0;
            this.green = 255;
            this.blue = 127;
        }
    }
}