using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
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
            this.red = 128;
            this.green = 128;
            this.blue = 128;
        }
    }
}