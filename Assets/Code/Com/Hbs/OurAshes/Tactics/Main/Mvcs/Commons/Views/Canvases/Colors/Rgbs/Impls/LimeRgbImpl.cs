using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Lime Rgb Implementation
    /// </summary>
    public class LimeRgbImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LimeRgbImpl()
        {
            this.colorID = ColorID.Lime;
            this.red = 0;
            this.green = 255;
            this.blue = 0;
        }
    }
}