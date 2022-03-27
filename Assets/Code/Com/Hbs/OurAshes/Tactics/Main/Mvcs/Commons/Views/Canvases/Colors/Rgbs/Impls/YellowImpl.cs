using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Yellow Rgb Implementation
    /// </summary>
    public class YellowImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public YellowImpl()
        {
            this.colorID = ColorID.Yellow;
            this.red = 255;
            this.green = 255;
            this.blue = 0;
        }
    }
}