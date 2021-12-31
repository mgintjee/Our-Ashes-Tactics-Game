using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Red Rgb Implementation
    /// </summary>
    public class RedRgbImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RedRgbImpl()
        {
            this.colorID = ColorID.Red;
            this.red = 255;
            this.green = 0;
            this.blue = 0;
        }
    }
}