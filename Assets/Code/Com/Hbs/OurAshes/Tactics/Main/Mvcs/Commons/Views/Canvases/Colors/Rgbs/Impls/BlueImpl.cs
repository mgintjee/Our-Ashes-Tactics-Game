using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Blue Rgb Implementation
    /// </summary>
    public class BlueImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BlueImpl()
        {
            this.red = 0;
            this.green = 0;
            this.blue = 255;
        }
    }
}