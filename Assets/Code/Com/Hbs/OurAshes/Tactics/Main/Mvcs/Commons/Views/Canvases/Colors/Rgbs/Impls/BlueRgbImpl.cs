using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Blue Rgb Implementation
    /// </summary>
    public class BlueRgbImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BlueRgbImpl()
        {
            this.colorID = ColorID.Blue;
            this.red = 0;
            this.green = 0;
            this.blue = 255;
        }
    }
}