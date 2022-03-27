using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Sienna Rgb Implementation
    /// </summary>
    public class SiennaImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SiennaImpl()
        {
            this.colorID = ColorID.Sienna;
            this.red = 160;
            this.green = 82;
            this.blue = 45;
        }
    }
}