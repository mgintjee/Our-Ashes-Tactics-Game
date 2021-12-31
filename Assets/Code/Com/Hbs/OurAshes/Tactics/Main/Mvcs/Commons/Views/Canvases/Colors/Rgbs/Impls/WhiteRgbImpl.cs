using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// White Rgb Implementation
    /// </summary>
    public class WhiteRgbImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public WhiteRgbImpl()
        {
            this.colorID = ColorID.White;
            this.red = 255;
            this.green = 255;
            this.blue = 255;
        }
    }
}