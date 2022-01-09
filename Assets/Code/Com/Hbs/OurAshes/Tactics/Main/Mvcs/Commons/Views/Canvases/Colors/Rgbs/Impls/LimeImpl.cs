using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Lime Rgb Implementation
    /// </summary>
    public class LimeImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LimeImpl()
        {
            this.red = 0;
            this.green = 255;
            this.blue = 0;
        }
    }
}