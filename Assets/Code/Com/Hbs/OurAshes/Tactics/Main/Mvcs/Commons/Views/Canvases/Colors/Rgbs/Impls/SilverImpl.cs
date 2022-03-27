using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Silver Rgb Implementation
    /// </summary>
    public class SilverImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SilverImpl()
        {
            this.colorID = ColorID.Silver;
            this.red = 192;
            this.green = 192;
            this.blue = 192;
        }
    }
}