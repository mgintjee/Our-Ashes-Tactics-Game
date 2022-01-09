using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// White Rgb Implementation
    /// </summary>
    public class WhiteImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public WhiteImpl()
        {
            this.red = 255;
            this.green = 255;
            this.blue = 255;
        }
    }
}