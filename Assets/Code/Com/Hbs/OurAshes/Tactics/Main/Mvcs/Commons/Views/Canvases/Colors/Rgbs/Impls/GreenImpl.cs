using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Green Rgb Implementation
    /// </summary>
    public class GreenImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GreenImpl()
        {
            this.red = 0;
            this.green = 128;
            this.blue = 0;
        }
    }
}